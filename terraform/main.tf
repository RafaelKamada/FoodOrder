
provider "aws" {
  region = var.regionDefault
}


resource "aws_eks_access_policy_association" "eks-access-policy" {
  cluster_name  = aws_eks_cluster.eks-cluster.name
  policy_arn    = var.policyArn
  principal_arn = var.principalArn

  access_scope {
    type = "cluster"
  }
}

resource "aws_eks_access_entry" "eks-access-entry" {
  cluster_name      = aws_eks_cluster.eks-cluster.name
  principal_arn     = var.principalArn
  kubernetes_groups = ["food-order-api-groups"]
  type              = "STANDARD"
}

resource "aws_lb" "food_order_lb" {
  name               = "food-order-lb"
  internal           = true
  load_balancer_type = "application"
  security_groups    = [aws_security_group.sg.id]
  subnets            = aws_subnet.private_subnets[*].id
}

resource "aws_lb_target_group" "food_order_tg" {
  name     = "food-order-tg"
  port     = 80
  protocol = "HTTP"
  vpc_id   = aws_vpc.main_vpc.id

  health_check {
    path                = "/health"
    interval            = 30
    timeout             = 5
    healthy_threshold   = 3
    unhealthy_threshold = 2
  }
}

resource "aws_lb_listener" "http" {
  load_balancer_arn = aws_lb.food_order_lb.arn
  port              = 80
  protocol          = "HTTP"

  default_action {
    type             = "forward"
    target_group_arn = aws_lb_target_group.food_order_tg.arn
  }
}

resource "aws_eks_node_group" "eks-node" {
  cluster_name    = aws_eks_cluster.eks-cluster.name
  node_group_name = var.nodeGroup
  node_role_arn   = var.labRole
  subnet_ids      = aws_subnet.private_subnets[*].id
  disk_size       = 50
  instance_types  = [var.instanceType]

  scaling_config {
    desired_size = 2
    min_size     = 1
    max_size     = 2
  }

  update_config {
    max_unavailable = 1
  }
}

resource "aws_eks_cluster" "eks-cluster" {
  name     = var.projectName
  role_arn = var.labRole
  
  vpc_config {
    subnet_ids         = aws_subnet.private_subnets[*].id
    security_group_ids = [aws_security_group.sg.id]
  }

  access_config {
    authentication_mode = var.accessConfig
  }
}

resource "aws_api_gateway_rest_api" "food_order_api" {
  name        = "food-order-api"
  description = "API Gateway para o Food Order API"
}

resource "aws_api_gateway_resource" "proxy" {
  rest_api_id = aws_api_gateway_rest_api.food_order_api.id
  parent_id   = aws_api_gateway_rest_api.food_order_api.root_resource_id
  path_part   = "{proxy+}"
}

resource "aws_api_gateway_method" "proxy" {
  rest_api_id   = aws_api_gateway_rest_api.food_order_api.id
  resource_id   = aws_api_gateway_resource.proxy.id
  http_method   = "ANY"
  authorization = "NONE"
}

resource "aws_api_gateway_integration" "load_balancer" {
  rest_api_id             = aws_api_gateway_rest_api.food_order_api.id
  resource_id             = aws_api_gateway_resource.proxy.id
  http_method             = aws_api_gateway_method.proxy.http_method
  type                    = "HTTP_PROXY"
  integration_http_method = "ANY"
  uri                     = "http://${aws_lb.food_order_lb.dns_name}"
}

resource "aws_api_gateway_deployment" "food_order_api" {
  depends_on = [aws_api_gateway_integration.load_balancer]
  rest_api_id = aws_api_gateway_rest_api.food_order_api.id
  stage_name  = "prod"
}

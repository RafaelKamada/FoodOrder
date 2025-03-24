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

  tags = {
    "eks.amazonaws.com/compute-type" = "ec2"  # Garante que não será "Fargate" Auto Mode
  }

}

resource "aws_eks_addon" "kube_proxy" {
  cluster_name = aws_eks_cluster.eks-cluster.name
  addon_name   = "kube-proxy"
}

resource "aws_eks_addon" "vpc_cni" {
  cluster_name = aws_eks_cluster.eks-cluster.name
  addon_name   = "vpc-cni"
}

resource "aws_eks_addon" "eks-node-monitoring-agent" {
  cluster_name = aws_eks_cluster.eks-cluster.name
  addon_name   = "eks-node-monitoring-agent"
}

resource "aws_eks_addon" "coredns" {
  cluster_name = aws_eks_cluster.eks-cluster.name
  addon_name   = "coredns"
  addon_version = "v1.11.4-eksbuild.2"

  depends_on = [
    aws_eks_node_group.eks-node
  ]
}

resource "aws_eks_addon" "eks-pod-identity-agent" {
  cluster_name = aws_eks_cluster.eks-cluster.name
  addon_name   = "eks-pod-identity-agent"
}


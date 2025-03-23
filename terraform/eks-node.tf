resource "aws_eks_node_group" "eks-node" {
  cluster_name    = aws_eks_cluster.eks-cluster.name
  node_group_name = var.nodeGroup
  node_role_arn   = var.labRole
  subnet_ids      = aws_subnet.private_subnets[*].id
  instance_types  = [var.instanceType]

  scaling_config {
    desired_size = 2
    min_size     = 1
    max_size     = 2
  } 

  update_config {
    max_unavailable = 1
  }

  depends_on = [
    aws_eks_cluster.eks-cluster,
    aws_vpc.main_vpc,
    aws_subnet.private_subnets,
    aws_security_group.sg
  ]

  tags = {
    "kubernetes.io/cluster/${var.projectName}" = "owned"
    Environment = var.environment
  }

  launch_template {
    name    = aws_launch_template.eks_launch_template.name
    version = aws_launch_template.eks_launch_template.latest_version
  }
}

resource "aws_launch_template" "eks_launch_template" {
  name = "eks-launch-template"

  block_device_mappings {
    device_name = "/dev/xvda"
    
    ebs {
      volume_size = 50
      volume_type = "gp2"
      delete_on_termination = true
    }
  }

  network_interfaces {
    associate_public_ip_address = false
    security_groups            = [aws_security_group.sg.id]
  }

  tag_specifications {
    resource_type = "instance"
    tags = {
      Name = "EKS-Node"
      "kubernetes.io/cluster/${var.projectName}" = "owned"
    }
  }

  user_data = base64encode(<<-EOF
MIME-Version: 1.0
Content-Type: multipart/mixed; boundary="==BOUNDARY=="

--==BOUNDARY==
Content-Type: text/x-shellscript; charset="us-ascii"

#!/bin/bash
/etc/eks/bootstrap.sh ${aws_eks_cluster.eks-cluster.name} \
  --b64-cluster-ca ${aws_eks_cluster.eks-cluster.certificate_authority[0].data} \
  --apiserver-endpoint ${aws_eks_cluster.eks-cluster.endpoint}

--==BOUNDARY==--
EOF
  )
}

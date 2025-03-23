resource "aws_security_group" "sg" {
  name        = "SG-${var.projectName}"
  description = "Security Group do Food Order API"
  vpc_id      = aws_vpc.main_vpc.id

  # Inbound
  ingress {
    description = "HTTP"
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    description = "EKS API Server"
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    description = "Allow TCP traffic on port 9000 from this security group"
    from_port   = 9000
    to_port     = 9000
    protocol    = "tcp"
    self        = true
  }

  ingress {
    description = "Allow all traffic from this security group"
    from_port   = 0
    to_port     = 0
    protocol    = "-1"  # -1 significa "todos os protocolos"
    self        = true
  }

  ingress {
    description = "Allow PostgreSQL traffic on port 5432 from this security group"
    from_port   = 5432
    to_port     = 5432
    protocol    = "tcp"
    self        = true
  }

  # Outbound
  egress {
    description = "All"
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

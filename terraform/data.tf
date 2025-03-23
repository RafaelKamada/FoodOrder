resource "aws_vpc" "main_vpc" {
  cidr_block = "172.31.0.0/16"

  tags = {
    Name        = "Main VPC"
    Environment = "production"
  }
}

resource "aws_subnet" "public_subnets" {
  count = 2
  vpc_id            = aws_vpc.main_vpc.id
  cidr_block        = cidrsubnet("172.31.0.0/16", 4, count.index + 2)
  availability_zone = element(["us-east-1a", "us-east-1b"], count.index)

  tags = {
    Name        = "Public Subnet ${count.index + 1}"
    Environment = "public"
    "kubernetes.io/role/elb"   = "1"
    "kubernetes.io/cluster/${var.projectName}" = "shared"
  }
}

resource "aws_subnet" "private_subnets" {
  count = 2
  vpc_id            = aws_vpc.main_vpc.id
  cidr_block        = cidrsubnet("172.31.0.0/16", 4, count.index)
  availability_zone = element(["us-east-1a", "us-east-1b"], count.index)

  tags = {
    Name        = "Private Subnet ${count.index + 1}"
    Environment = "private"
    "kubernetes.io/role/internal-elb"   = "1"
    "kubernetes.io/cluster/${var.projectName}" = "shared"
  }
}

resource "aws_internet_gateway" "main" {
  vpc_id = aws_vpc.main_vpc.id

  tags = {
    Name = "Main Internet Gateway"
  }
}

resource "aws_eip" "eip_public_1" {
  domain = "vpc"

  tags = {
    Name = "eip_public_1"
  }
}

resource "aws_nat_gateway" "nat_public" {
  allocation_id = aws_eip.eip_public_1.id
  subnet_id     = aws_subnet.public_subnets[0].id

  tags = {
    Name = "NAT Gateway Public 1"
  }
}

resource "aws_eip" "eip_public_2" {
  domain = "vpc"

  tags = {
    Name = "eip_public_2"
  }
}

resource "aws_nat_gateway" "nat_private" {
  allocation_id = aws_eip.eip_public_2.id
  subnet_id     = aws_subnet.public_subnets[1].id

  tags = {
    Name = "NAT Gateway Public 2"
  }
}

resource "aws_route_table" "public_rt" {
  vpc_id = aws_vpc.main_vpc.id

  tags = {
    Name = "public_rt"
  }
}

resource "aws_route" "public_route" {
  route_table_id         = aws_route_table.public_rt.id
  destination_cidr_block = "0.0.0.0/0"
  gateway_id             = aws_internet_gateway.main.id
}

resource "aws_route_table_association" "public_subnet_association" {
  count          = 2
  subnet_id      = aws_subnet.public_subnets[count.index].id
  route_table_id = aws_route_table.public_rt.id
}

resource "aws_route_table" "private_rt" {
  vpc_id = aws_vpc.main_vpc.id

  tags = {
    Name = "private_route"
  }
}

resource "aws_route" "private_nat_gateway" {
  route_table_id         = aws_route_table.private_rt.id
  destination_cidr_block = "0.0.0.0/0"
  nat_gateway_id         = aws_nat_gateway.nat_public.id
}

resource "aws_route_table_association" "private" {
  count          = length(aws_subnet.private_subnets[*].id)
  subnet_id      = aws_subnet.private_subnets[count.index].id
  route_table_id = aws_route_table.private_rt.id
}

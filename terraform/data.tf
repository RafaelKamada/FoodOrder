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
  }
}

resource "aws_eip" "nat_public" {
  domain = "vpc"
}

resource "aws_nat_gateway" "nat_public" {
  allocation_id = aws_eip.nat_public.id
  subnet_id     = aws_subnet.public_subnets[0].id

  tags = {
    Name = "NAT Gateway Public"
  }
}

resource "aws_eip" "nat_private" {
  domain = "vpc"
}

resource "aws_nat_gateway" "nat_private" {
  allocation_id = aws_eip.nat_private.id
  subnet_id     = aws_subnet.public_subnets[1].id

  tags = {
    Name = "NAT Gateway Private"
  }
}

resource "aws_route_table" "private_rt" {
  vpc_id = aws_vpc.main_vpc.id
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

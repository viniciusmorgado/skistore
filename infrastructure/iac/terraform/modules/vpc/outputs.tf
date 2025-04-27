output "vpc_id" {
  description = "The ID of the VPC"
  value       = aws_vpc.main.id
}

output "public_subnets" {
  description = "IDs of the public subnets"
  value       = [for s in aws_subnet.public : s.id]
}

output "private_subnets" {
  description = "IDs of the private subnets"
  value       = [for s in aws_subnet.private : s.id]
}
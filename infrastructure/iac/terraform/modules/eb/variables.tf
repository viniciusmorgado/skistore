variable "project_name" {
  description = "Project name prefix for AWS resources."
  type        = string
}

variable "vpc_id" {
  description = "VPC ID for deploying the Elastic Beanstalk environment."
  type        = string
}

variable "public_subnet_ids" {
  description = "List of public subnet IDs for ALB."
  type        = list(string)
}

variable "private_subnet_ids" {
  description = "List of private subnet IDs for EB instances."
  type        = list(string)
}

variable "db_endpoint" {
  description = "Database endpoint to be set as environment variable."
  type        = string
}

variable "instance_type" {
  description = "EC2 instance type for EB environment."
  type        = string
  default     = "t3.small"
}

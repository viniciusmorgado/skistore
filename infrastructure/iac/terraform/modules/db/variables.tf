variable "project_name" {
  description = "Project name prefix for AWS resources."
  type        = string
}

variable "master_username" {
  description = "Master username for the Aurora DB."
  type        = string
}

variable "master_password" {
  description = "Master password for the Aurora DB."
  type        = string
  sensitive   = true
}

variable "vpc_id" {
  description = "VPC where the database will be deployed."
  type        = string
}

variable "db_subnet_ids" {
  description = "Subnet IDs for the database subnet group."
  type        = list(string)
}

# TODO? USEFUL DURING TESTS BUT EXPOSE DB TO THE INTERNET
# variable "allowed_cidr_blocks" {
#   description = "CIDR blocks allowed to connect to the database (for testing defaults to anywhere)."
#   type        = list(string)
#   default     = ["0.0.0.0/0"]
# }

variable "allowed_security_group_id" {
  description = "Security Group ID allowed to connect to the database (typically Elastic Beanstalk instances' SG)."
  type        = string
}

variable "db_instance_class" {
  description = "Instance class for the Aurora DB instances (example: db.serverless, db.r6g.large, etc.)"
  type        = string
  default     = "db.r6g.large"
}

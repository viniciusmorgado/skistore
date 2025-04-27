variable "region" {
  default = "us-east-2"
}

variable "project_name" {
  description = "Project name prefix"
  type        = string
}

variable "db_user" {
  description = "Database username"
  type        = string
}

variable "db_pass" {
  description = "Database password"
  type        = string
  sensitive   = true
}

output "vpc_id" {
  description = "ID of the VPC"
  value       = module.vpc.vpc_id
}

output "public_subnets" {
  description = "List of public subnet IDs"
  value       = module.vpc.public_subnets
}

output "private_subnets" {
  description = "List of private subnet IDs"
  value       = module.vpc.private_subnets
}

output "frontend_bucket" {
  description = "Name of the S3 bucket hosting the frontend"
  value       = module.s3_cloudfront.bucket_id
}

output "cdn_domain_name" {
  description = "CloudFront distribution domain name"
  value       = module.s3_cloudfront.cdn_domain_name
}

output "eb_application_name" {
  description = "Name of the Elastic Beanstalk Application"
  value       = module.eb.eb_application_name
}

output "eb_environment_name" {
  description = "Name of the Elastic Beanstalk Environment"
  value       = module.eb.eb_environment_name
}

output "alb_security_group_id" {
  description = "Security Group ID for the Application Load Balancer"
  value       = module.eb.alb_security_group_id
}

output "eb_security_group_id" {
  description = "Security Group ID for the EB instances"
  value       = module.eb.eb_security_group_id
}

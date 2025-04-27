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

# output "eb_app_name" {
#   value = module.eb.app_name
# }

# output "eb_env_name" {
#   value = module.eb.environment_name
# }

# output "eb_url" {
#   description = "URL of the EB environment"
#   value       = module.eb.environment_endpoint
# }

output "frontend_bucket" {
  description = "Name of the S3 bucket hosting the frontend"
  value       = module.s3_cloudfront.bucket_id
}

output "cdn_domain_name" {
  description = "CloudFront distribution domain name"
  value       = module.s3_cloudfront.cdn_domain_name
}

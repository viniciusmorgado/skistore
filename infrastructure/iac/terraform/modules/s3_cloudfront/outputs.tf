output "bucket_id" {
  description = "Name of the S3 bucket for the frontend"
  value       = aws_s3_bucket.frontend.id
}

output "cdn_id" {
  description = "CloudFront distribution ID"
  value       = aws_cloudfront_distribution.cdn.id
}

output "cdn_domain_name" {
  description = "Domain name of the CloudFront distribution"
  value       = aws_cloudfront_distribution.cdn.domain_name
}

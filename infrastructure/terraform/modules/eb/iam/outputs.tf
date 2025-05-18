output "eb_service_role_name" {
  description = "Elastic Beanstalk service role name."
  value       = aws_iam_role.eb_service_role.name
}

output "eb_instance_profile_name" {
  description = "Elastic Beanstalk EC2 instance profile name."
  value       = aws_iam_instance_profile.eb_instance_profile.name
}

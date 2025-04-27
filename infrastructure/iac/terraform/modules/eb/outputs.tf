output "eb_application_name" {
  description = "Elastic Beanstalk Application Name"
  value       = aws_elastic_beanstalk_application.app.name
}

output "eb_environment_name" {
  description = "Elastic Beanstalk Environment Name"
  value       = aws_elastic_beanstalk_environment.env.name
}

output "alb_security_group_id" {
  description = "Security Group ID for the Load Balancer"
  value       = aws_security_group.alb_sg.id
}

output "eb_security_group_id" {
  description = "Security Group ID for Elastic Beanstalk instances"
  value       = aws_security_group.eb_sg.id
}

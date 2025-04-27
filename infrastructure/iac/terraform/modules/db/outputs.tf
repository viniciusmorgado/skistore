output "db_cluster_endpoint" {
  description = "The endpoint of the Aurora DB cluster."
  value       = aws_rds_cluster.aurora.endpoint
}

output "db_cluster_id" {
  description = "The ID of the Aurora DB cluster."
  value       = aws_rds_cluster.aurora.id
}

output "db_security_group_id" {
  description = "The ID of the database security group."
  value       = aws_security_group.db_sg.id
}

output "db_subnet_group_name" {
  description = "The name of the DB subnet group."
  value       = aws_db_subnet_group.main.name
}

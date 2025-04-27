# Security group for the database
resource "aws_security_group" "db_sg" {
  name        = "${var.project_name}-db-sg"
  description = "Allow inbound access to Aurora PostgreSQL"
  vpc_id      = var.vpc_id

  ingress {
    from_port   = 5432
    to_port     = 5432
    protocol    = "tcp"
    cidr_blocks = var.allowed_cidr_blocks
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "${var.project_name}-db-sg"
  }
}

# Subnet group for Aurora RDS
resource "aws_db_subnet_group" "main" {
  name       = "${var.project_name}-db-subnet-group"
  subnet_ids = var.db_subnet_ids

  tags = {
    Name = "${var.project_name}-db-subnet-group"
  }
}

# Aurora PostgreSQL cluster
resource "aws_rds_cluster" "aurora" {
  cluster_identifier     = "${var.project_name}-aurora"
  engine                 = "aurora-postgresql"
  master_username        = var.master_username
  master_password        = var.master_password
  vpc_security_group_ids = [aws_security_group.db_sg.id]
  db_subnet_group_name   = aws_db_subnet_group.main.name
  skip_final_snapshot    = true
  deletion_protection    = false
}

# Writer Instance for Aurora Cluster
resource "aws_rds_cluster_instance" "aurora_writer" {
  identifier              = "${var.project_name}-aurora-writer"
  cluster_identifier      = aws_rds_cluster.aurora.id
  instance_class          = var.db_instance_class
  engine                  = aws_rds_cluster.aurora.engine
  engine_version          = aws_rds_cluster.aurora.engine_version
  publicly_accessible     = false
  db_subnet_group_name    = aws_db_subnet_group.main.name
  db_parameter_group_name = null
}

# Reader Instance for Aurora Cluster
resource "aws_rds_cluster_instance" "aurora_reader" {
  identifier              = "${var.project_name}-aurora-reader"
  cluster_identifier      = aws_rds_cluster.aurora.id
  instance_class          = var.db_instance_class
  engine                  = aws_rds_cluster.aurora.engine
  engine_version          = aws_rds_cluster.aurora.engine_version
  publicly_accessible     = false
  db_subnet_group_name    = aws_db_subnet_group.main.name
  db_parameter_group_name = null
}

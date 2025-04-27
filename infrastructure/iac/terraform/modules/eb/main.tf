# Security Group for the EB application
resource "aws_security_group" "eb_sg" {
  name        = "${var.project_name}-eb-sg"
  description = "Allow inbound traffic from ALB to Elastic Beanstalk instances"
  vpc_id      = var.vpc_id

  ingress {
    from_port       = 80
    to_port         = 80
    protocol        = "tcp"
    security_groups = [aws_security_group.alb_sg.id] # only ALB can talk to instances
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "${var.project_name}-eb-sg"
  }
}

# Security Group for the Load Balancer
resource "aws_security_group" "alb_sg" {
  name        = "${var.project_name}-alb-sg"
  description = "Allow inbound HTTP traffic to ALB"
  vpc_id      = var.vpc_id

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }

  tags = {
    Name = "${var.project_name}-alb-sg"
  }
}

# Elastic Beanstalk Application
resource "aws_elastic_beanstalk_application" "app" {
  name        = "${var.project_name}-app"
  description = "Elastic Beanstalk Application for ${var.project_name}"
}

# Elastic Beanstalk Environment (Load Balanced)
resource "aws_elastic_beanstalk_environment" "env" {
  name                = "${var.project_name}-env"
  application         = aws_elastic_beanstalk_application.app.name
  # https://docs.aws.amazon.com/elasticbeanstalk/latest/platforms/platform-history-dotnetlinux.html
  solution_stack_name = "64bit Amazon Linux 2023 v3.4.1 running .NET 9" # Use this to update the runtime
  tier                = "WebServer"

  setting {
    namespace = "aws:ec2:vpc"
    name      = "VPCId"
    value     = var.vpc_id
  }

  setting {
    namespace = "aws:ec2:vpc"
    name      = "Subnets"
    value     = join(",", var.private_subnet_ids) # Application instances in PRIVATE subnets
  }

  setting {
    namespace = "aws:ec2:vpc"
    name      = "ELBSubnets"
    value     = join(",", var.public_subnet_ids) # ALB in PUBLIC subnets
  }

  setting {
    namespace = "aws:ec2:vpc"
    name      = "ELBScheme"
    value     = "internet-facing"
  }

  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "SecurityGroups"
    value     = aws_security_group.eb_sg.id
  }

  setting {
    namespace = "aws:elasticbeanstalk:environment"
    name      = "LoadBalancerType"
    value     = "application" # Application Load Balancer
  }

  setting {
    namespace = "aws:elasticbeanstalk:application:environment"
    name      = "DB_HOST"
    value     = var.db_endpoint # Database endpoint for the app (even if unused yet)
  }
  
  # Optional: Instance type setting
  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "InstanceType"
    value     = var.instance_type
  }

  setting {
    namespace = "aws:autoscaling:launchconfiguration"
    name      = "IamInstanceProfile"
    value     = module.eb_iam.eb_instance_profile_name
  }

  setting {
    namespace = "aws:elasticbeanstalk:environment"
    name      = "ServiceRole"
    value     = module.eb_iam.eb_service_role_name
  }
}

module "eb_iam" {
  source = "./iam"
  project_name = var.project_name
}

# resource "aws_elastic_beanstalk_application" "app" {
#   name = "${var.project_name}-backend"
# }

# resource "aws_elastic_beanstalk_environment" "env" {
#   name                = "${var.project_name}-backend-env"
#   application         = aws_elastic_beanstalk_application.app.name
#   solution_stack_name = var.solution_stack_name

#   # VPC placement
#   setting {
#     namespace = "aws:ec2:vpc"
#     name      = "VPCId"
#     value     = var.vpc_id
#   }

#   setting {
#     namespace = "aws:ec2:vpc"
#     name      = "Subnets"
#     value     = join(",", var.private_subnets)
#   }

#   setting {
#     namespace = "aws:ec2:vpc"
#     name      = "ELBSubnets"
#     value     = join(",", var.public_subnets)
#   }

#   # Free-tier instance
#   setting {
#     namespace = "aws:autoscaling:launchconfiguration"
#     name      = "InstanceType"
#     value     = var.instance_type
#   }

#   # Pass the DB secret ARN
#   setting {
#     namespace = "aws:elasticbeanstalk:application:environment"
#     name      = "DB_SECRET_ARN"
#     value     = var.secrets_arn
#   }
# }

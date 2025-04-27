# IAM Policy for Elastic Beanstalk Service Role
resource "aws_iam_policy" "eb_service_policy" {
  name        = "${var.project_name}-eb-service-policy"
  description = "Policy for Elastic Beanstalk service role"

  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "autoscaling:*",
          "cloudwatch:*",
          "ec2:*",
          "elasticloadbalancing:*",
          "s3:*",
          "sns:*",
          "cloudformation:*",
          "rds:*",
          "sqs:*",
          "ecs:*",
          "logs:*",
          "iam:PassRole"
        ]
        Resource = "*"
      }
    ]
  })
}

# Service Role for Elastic Beanstalk
resource "aws_iam_role" "eb_service_role" {
  name = "${var.project_name}-eb-service-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Principal = {
          Service = "elasticbeanstalk.amazonaws.com"
        }
        Action = "sts:AssumeRole"
      }
    ]
  })
}

# Attach Policy to Service Role
resource "aws_iam_role_policy_attachment" "eb_service_policy_attachment" {
  role       = aws_iam_role.eb_service_role.name
  policy_arn = aws_iam_policy.eb_service_policy.arn
}

# IAM Policy for EC2 Instance Profile
resource "aws_iam_policy" "eb_ec2_instance_policy" {
  name        = "${var.project_name}-eb-ec2-policy"
  description = "Policy for EC2 instances launched by Elastic Beanstalk"

  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "cloudwatch:PutMetricData",
          "ec2:Describe*",
          "elasticloadbalancing:Describe*",
          "autoscaling:Describe*",
          "s3:Get*",
          "s3:List*",
          "logs:CreateLogGroup",
          "logs:CreateLogStream",
          "logs:PutLogEvents"
        ]
        Resource = "*"
      }
    ]
  })
}

# Role for EC2 instances
resource "aws_iam_role" "eb_ec2_role" {
  name = "${var.project_name}-eb-ec2-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Principal = {
          Service = "ec2.amazonaws.com"
        }
        Action = "sts:AssumeRole"
      }
    ]
  })
}

# Attach Policy to EC2 Role
resource "aws_iam_role_policy_attachment" "eb_ec2_policy_attachment" {
  role       = aws_iam_role.eb_ec2_role.name
  policy_arn = aws_iam_policy.eb_ec2_instance_policy.arn
}

# Instance Profile for EC2 instances
resource "aws_iam_instance_profile" "eb_instance_profile" {
  name = "${var.project_name}-eb-ec2-instance-profile"
  role = aws_iam_role.eb_ec2_role.name
}

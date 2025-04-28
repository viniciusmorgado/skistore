# Ski Store API
API for Ski Store project

## Development Setup Requirements
- .NET 8 SDK
- Docker Desktop
- Git
- AWS CLI (for cloud deploy only)

## Getting Started

1. Clone the repository
```bash
git clone https://github.com/viniciusmorgado/skistore-api.git
```

2. Create a `.env` file in the root directory with these variables:
```
POSTGRES_USER=your_username
POSTGRES_PASSWORD=your_password
```
Note: Choose any username/password for development, but remember to update `appsettings.Development.json` with the same credentials.

3. Start the PostgreSQL container:
```bash
docker-compose up -d
```

4. Run the API:
```bash
dotnet restore
dotnet run
```

## Database Configuration

The PostgreSQL container runs with these specifications:
- CPU: 1 core (minimum 0.5)
- Memory: 1GB (minimum 512MB)
- Port: 5432 (default)

These resources are sufficient for local development.

## Infrastructure

### On-promise with Docker Container

### On-promise without Docker Container

### AWS with Elastic Beanstalk and Terraform

We use Terraform to create a managed instance of elastic beanstalk in AWS, you need to setup the Terraform CLI first regardless if you are deployment the infrastructure via a pipeline, or if you are testing it direct on your machine.

The terraform.tfstate saves the state of the infrastructure it is essentialy for the continues update of the infrastructure, but because contains confidential information is never commited on the repository, instead we normally save into a bucket, because we are using AWS for this project the bucket will be the S3. To not attache the bucket for the state with the creation of the rest of the infrastructure create the bucket by hand using aws cli:

´´´
aws s3api create-bucket \
  --bucket skistore-state-bucket \
  --region us-east-2 \
  --create-bucket-configuration LocationConstraint=us-east-2
´´´

On Windows (remove the break lines):

´´´
aws s3api create-bucket --bucket skistore-state-bucket --region us-east-2 --create-bucket-configuration LocationConstraint=us-east-2
´´´

Before we go with the infrastructure, let's create the secrets manager:



Then inside of infrastructure/iac/terraform/environments/prod:

To apply the entire infrastructure:

terraform init
terraform plan
terraform apply -auto-approve

To apply a single module using Terraform:

terraform init
terraform plan "-target=module.vpc"
terraform apply "-target=module.vpc" -auto-approve


#### USE appsettings.json as template to fill the necessary information to run this project
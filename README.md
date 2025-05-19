# SkiStore Monorepo

Monorepo for the SkiStore eShop application with Angular (TypeScript) and ASP.NET Core (C#)

High level directory structure:

* `client/` - Angular frontend application
* `server/` - C# .NET Backend Application
* `infrastructure/` - DevOps and infra files (Terraform/AWS, Docker, Apache Airflow DAGs)

## Development Requirements

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/)
* [Git](https://git-scm.com/)

## Production Requirements

* [AWS CLI](https://aws.amazon.com/cli/) (configured with credentials for your AWS account)
* [GitHub Actions](https://github.com/features/actions)

### Required GitHub Secrets

| Secret Name                 | Description                                                                                                             |
| --------------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| `AWS_ACCESS_KEY_ID`         | Access key ID for an IAM user with permissions to manage AWS infrastructure and resources.                              |
| `AWS_SECRET_ACCESS_KEY`     | Secret access key paired with the IAM access key. Used for authenticating Terraform and pipeline operations.            |
| `AWS_REGION`                | AWS region where all infrastructure will be provisioned (e.g., `us-east-1`).                                            |
| `STATE_BUCKET_NAME`         | Name of the S3 bucket that stores the Terraform state file. Must be globally unique.                                    |
| `LOCK_IN_DYNAMO_TABLE_NAME` | Name of the DynamoDB table used by Terraform to lock the state file during apply operations (prevents race conditions). |
| `TF_PROJECT_NAME`           | Project identifier used for resource naming, tagging, and isolation (e.g., `my-app-prod`).                              |
| `TF_DB_USER`                | Username for the PostgreSQL database provisioned by Terraform.                                                          |
| `TF_DB_PASS`                | Password for the PostgreSQL database user. Ensure strong password complexity.                                           |
| `STATE_KMS_KEY_ARN`         | ARN of the KMS key used to encrypt the Terraform state bucket. This must be created and configured manually.            |

## Getting Started (Development)

1. **Clone the repository**:

   ```bash
   git clone https://github.com/viniciusmorgado/skistore-api.git
   ```

2. **Create a development settings file**:

   In `server/skistore-api/src/SkiStore.Api`, create a file named `appsettings.Development.json` using `appsettings.json` as a template:

   ```json
   {
     "Kestrel": {
       "Endpoints": {
         "Http": {
           "Url": "localhost:5001"
         }
       }
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Information"
       }
     },
     "ConnectionStrings": {
       "DefaultConnection": "REPLACE_WITH_POSTGRES_CONNECTION_STRING",
       "Redis": "REPLACE_WITH_REDIS_ENDPOINT"
     },
     "CorsSettings": {
       "AllowedOrigins": [
         "http://localhost:5001"
       ]
     },
     "StripeSettings": {
       "PublicKey": "REPLACE_WITH_STRIPE_PUBLISHABLE_KEY",
       "PrivateKey": "REPLACE_WITH_STRIPE_SECRET_KEY"
     }
   }
   ```

   > **Note:** `appsettings.Development.json` is excluded from version control.

3. **Create a `.env` file**:

   Inside `infrastructure/docker`, create a `.env` file:

   ```bash
   POSTGRES_USER=your_username
   POSTGRES_PASSWORD=your_password
   ```

   > **Reminder:** Use the same credentials in your `appsettings.Development.json`.

4. **Start Docker containers**:

   Navigate to `infrastructure/docker` and run:

   ```bash
   docker-compose up -d
   ```

5. **Run the API**:

   ```bash
   dotnet restore
   dotnet run
   ```

## Database Configuration

**PostgreSQL**:

* CPU: 1 core (min 0.5)
* Memory: 1 GB (min 512 MB)
* Port: 5432

**Redis**:

* CPU: 0.5 core
* Memory: 256 MB
* Port: 6379

These resources are sufficient for local development.

## Infrastructure

### AWS with Terraform and GitHub Actions

The production infrastructure is provisioned using **Terraform** through a fully automated **GitHub Actions pipeline**.

#### Initial Setup

1. **Manually create the KMS key**:

   You must create a secure KMS key manually before provisioning infrastructure. This key will be used to encrypt the Terraform state bucket.

   * Run this command to create the key:

     ```bash
     aws kms create-key \
       --description "KMS key for Terraform state bucket encryption" \
       --key-usage ENCRYPT_DECRYPT \
       --customer-master-key-spec SYMMETRIC_DEFAULT \
       --tags TagKey=Environment,TagValue=Production
     ```

   * Assign an alias to the key:

     ```bash
     aws kms create-alias \
       --alias-name alias/state-bucket-key \
       --target-key-id <KEY_ID>
     ```

   * Get the ARN of the key (used in the pipeline secret):

     ```bash
     aws kms describe-key \
       --key-id alias/state-bucket-key \
       --query "KeyMetadata.Arn" \
       --output text
     ```

     Example output:

     ```text
     arn:aws:kms:us-east-1:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab
     ```

   * Save this full ARN in GitHub Secrets as `STATE_KMS_KEY_ARN`

   * Attach a secure policy (see project docs for policy JSON)

2. **Push to `main`**:

   The GitHub Actions pipeline will automatically:

   * Create the S3 state bucket
   * Apply encryption, access block, and versioning settings
   * Create the DynamoDB lock table
   * Validate and apply all Terraform-managed infrastructure

#### Terraform Manual Usage (optional)

To run Terraform locally (optional but supported):

```bash
cd infrastructure/iac/terraform/environments/prod
terraform init
terraform plan
terraform apply -auto-approve
```

To target a specific module:

```bash
terraform plan -target=module.vpc
terraform apply -target=module.vpc -auto-approve
```

#### Destroying the Infrastructure

To fully remove the infrastructure:

1. **Run Terraform destroy**:

```bash
terraform destroy \
  -var="region=..." \
  -var="project_name=..." \
  -var="db_user=..." \
  -var="db_pass=..."
```

2. **Manually delete Terraform backend resources**:

```bash
aws s3 rb s3://<STATE_BUCKET_NAME> --force
aws dynamodb delete-table --table-name <LOCK_IN_DYNAMO_TABLE_NAME>
```

3. **(Optional)** Schedule deletion of the KMS key:

```bash
aws kms schedule-key-deletion --key-id <KMS_KEY_ID> --pending-window-in-days 7
```

## License

Skistore is made available under the [Server Side Public License, version 1 (SSPL)](./LICENSE).

You can also read the official license text at:
[https://www.mongodb.com/legal/licensing/server-side-public-license](https://www.mongodb.com/legal/licensing/server-side-public-license)

Copyright © 2025 Vinicius Morgado

This is **source-available** software: you are free to view, use, and modify the source code under the terms of the SSPL, as published by MongoDB, Inc.

⚠️ **Important**: If you make the functionality of Skistore available to third parties as a service, you are required by the SSPL to release the complete source code of your service infrastructure under the same license.

This project is not affiliated with, endorsed by, or sponsored by MongoDB, Inc. MongoDB is the author of the SSPL license only.

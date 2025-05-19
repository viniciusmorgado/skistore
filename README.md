# Ski Store Monorepo

Monorepo for the SkiStore ecommerce application

High level directory structure:

- client/ - Angular frontend application
- server/ - C# .NET Backend Application
- infrastructure - DevOps and infra files (Terraform/AWS, Docker, Apache Airflow DAGs)

## Development Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Git](https://git-scm.com/)

## Production Requirements

- [AWS CLI](https://aws.amazon.com/cli/) (for cloud deployments)
- Docker (for on-premise deployments)

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

   Inside `infrastructure/containers/docker`, create a `.env` file:

   ```bash
   POSTGRES_USER=your_username
   POSTGRES_PASSWORD=your_password
   ```

   > **Reminder:** Use the same credentials in your `appsettings.Development.json`.

4. **Start Docker containers**:

   Navigate to `infrastructure/containers/docker` and run:

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
- CPU: 1 core (min 0.5)
- Memory: 1 GB (min 512 MB)
- Port: 5432

**Redis**:
- CPU: 0.5 core
- Memory: 256 MB
- Port: 6379

These resources are sufficient for local development.

<<<<<<< HEAD
## Contributing

This project demonstrates two different approaches to repository implementation:

1. **Main Repository (Traditional Pattern)**
    - Located in the main repository
    - Uses conventional repository pattern implementation

2. **Main-Generic Repository**
    - Implements generic repository with specification pattern
    - Available in the generic repository branch

### Contribution Guidelines

When contributing to this project:
1. Assess your use case requirements
2. Choose the appropriate repository implementation
3. Follow the existing pattern in your chosen branch
4. Maintain consistent code style
5. Include unit tests for new features

The choice between implementations should be based on your specific project requirements and needs.
=======
## Infrastructure

### AWS with Elastic Beanstalk and Terraform

We use Terraform to manage AWS Elastic Beanstalk infrastructure.

**Important:** Terraform state (`terraform.tfstate`) is sensitive and not committed to Git. It is stored in an S3 bucket.

**Create the S3 bucket manually:**

```bash
aws s3api create-bucket \
  --bucket skistore-state-bucket \
  --region us-east-2 \
  --create-bucket-configuration LocationConstraint=us-east-2
```

**On Windows (no line breaks):**

```bash
aws s3api create-bucket --bucket skistore-state-bucket --region us-east-2 --create-bucket-configuration LocationConstraint=us-east-2
```

**Apply Infrastructure:**

Inside `infrastructure/iac/terraform/environments/prod`, run:

```bash
terraform init
terraform plan
terraform apply -auto-approve
```

**Apply Specific Module:**

```bash
terraform init
```
```
terraform plan -target=module.vpc
terraform apply -target=module.vpc -auto-approve
```

## License

Skistore is made available under the [Server Side Public License, version 1 (SSPL)](./LICENSE).

You can also read the official license text at:  
[https://www.mongodb.com/legal/licensing/server-side-public-license](https://www.mongodb.com/legal/licensing/server-side-public-license)

Copyright © 2025 Vinicius Morgado

This is **source-available** software: you are free to view, use, and modify the source code under the terms of the SSPL, as published by MongoDB, Inc.

⚠️ **Important**: If you make the functionality of Skistore available to third parties as a service, you are required by the SSPL to release the complete source code of your service infrastructure under the same license.

This project is not affiliated with, endorsed by, or sponsored by MongoDB, Inc. MongoDB is the author of the SSPL license only.

terraform {
  backend "s3" {
    bucket  = "skistore-tf-state"
    key     = "terraform/skistore-infra.tfstate"
    region  = "us-east-2"
    encrypt = true
    dynamodb_table = "skistore-terraform-locks" # <-- points to the table created by Terraform DynamoDB for Lock-in the file during update.
  }
}

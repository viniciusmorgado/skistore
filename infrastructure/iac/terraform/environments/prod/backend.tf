terraform {
  backend "s3" {
    bucket  = "skistore-state-bucket"
    key     = "terraform/skistore-infra.tfstate"
    region  = "us-east-2"
    encrypt = true
  }
}

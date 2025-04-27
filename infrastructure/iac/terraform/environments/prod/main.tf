module "vpc" {
  source       = "../../modules/vpc"
  project_name = var.project_name
}

module "db" {
  source          = "../../modules/db"
  project_name    = var.project_name
  master_username = var.db_user
  master_password = var.db_pass
  vpc_id          = module.vpc.vpc_id
  db_subnet_ids   = module.vpc.private_subnets
}

module "eb" {
  source            = "../../modules/eb" # Adjust if your path differs
  project_name      = var.project_name
  vpc_id            = module.vpc.vpc_id
  public_subnet_ids = module.vpc.public_subnets
  private_subnet_ids = module.vpc.private_subnets
  db_endpoint       = module.db.db_cluster_endpoint
}

module "s3_cloudfront" {
  source       = "../../modules/s3_cloudfront"
  project_name = var.project_name
}

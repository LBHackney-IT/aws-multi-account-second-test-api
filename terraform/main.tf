provider "aws" {
  region  = "eu-west-2"
  version = "~> 2.0"
}

data "aws_iam_role" "ec2_container_service_role" {
  name = "ecsServiceRole"
}

data "aws_iam_role" "ecs_task_execution_role" {
  name = "ecsTaskExecutionRole"
}

terraform {
  backend "s3" {
    bucket  = "multi-acc-terraform-state-testing"
    encrypt = true
    region  = "eu-west-2"
    key     = "services/test-api-two/state"
  }
}


module "development" {
  # Delete as appropriate:
  source = "github.com/LBHackney-IT/aws-hackney-components-per-service-terraform.git//modules/environment/backend?ref=master"
  #source = "github.com/LBHackney-IT/aws-mat-components-per-service-terraform.git//modules/environment/frontend?ref=master"
  # TF-UPGRADE-TODO: In Terraform v0.11 and earlier, it was possible to
  # reference a relative module source without a preceding ./, but it is no
  # longer supported in Terraform v0.12.
  #
  # If the below module source is indeed a relative local path, add ./ to the
  # start of the source string. If that is not the case, then leave it as-is
  # and remove this TODO comment.
 # source                      = "./modules/environment/backend/"
  cluster_name                = "testing-terraform" # Replace with your cluster name.
  ecr_name                    = "hackney/test-api-two"
  environment_name            = "development"
  application_name            = "test-api-two"    # Replace with your application name.
  security_group_name         = "test-terraform" # Replace with your security group name .
  vpc_name                    = "vpc-testing-terraform"
  host_port                   = 1102
  port                        = 1102
  desired_number_of_ec2_nodes = 2
  lb_prefix                   = "nlb-test-terraform"
  ecs_execution_role          = data.aws_iam_role.ecs_task_execution_role.arn
  lb_iam_role_arn             = data.aws_iam_role.ec2_container_service_role.arn

  task_definition_environment_variables = {
    ASPNETCORE_ENVIRONMENT = "development"
  }

  task_definition_environment_variable_count = 2

  task_definition_secrets      = {}
  task_definition_secret_count = 0
}

/*   ADD ANY OTHER CUSTOM RESOURCES REQUIRED HERE      */

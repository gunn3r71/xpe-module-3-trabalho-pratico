module "start_instance_rule" {
  source = "./modules/event-rules"
  event_rule_name = "start_ec2_instances"
  lambda_arn = var.start_instance_lambda.Arn
  lambda_function_name = var.start_instance_lambda.Name
  lambda_schedule_expression = var.start_instance_lambda.Cron
}

module "stop_instance_rule" {
  source = "./modules/event-rules"
  event_rule_name = "stop_ec2_instances"
  lambda_arn = var.stop_instance_lambda.Arn
  lambda_function_name = var.stop_instance_lambda.Name
  lambda_schedule_expression = var.stop_instance_lambda.Cron
}

module "change_instance_type_to_up_rule" {
  source = "./modules/event-rules"
  event_rule_name = "change_instance_ec2_up"
  lambda_arn = var.up_scaling_instance_lambda.Arn
  lambda_function_name = var.up_scaling_instance_lambda.Name
  lambda_schedule_expression = var.up_scaling_instance_lambda.Cron
  event_raw = var.up_scaling_instance_lambda.TargetInstanceType
}

module "change_instance_type_to_down_rule" {
  source = "./modules/event-rules"
  event_rule_name = "change_instance_ec2_down"
  lambda_arn = var.down_scaling_instance_lambda.Arn
  lambda_function_name = var.down_scaling_instance_lambda.Name
  lambda_schedule_expression = var.down_scaling_instance_lambda.Cron
  event_raw = var.down_scaling_instance_lambda.TargetInstanceType
}
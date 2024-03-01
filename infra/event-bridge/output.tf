output "start_rule_id" {
  value = module.start_instance_rule.rule_id
}

output "stop_rule_id" {
    value = module.stop_instance_rule.rule_id
}

output "up_rule_id" {
    value = module.change_instance_type_to_up_rule.rule_id
}

output "down_rule_id" {
    value = module.change_instance_type_to_down_rule.rule_id
}
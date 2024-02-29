output "instance-id" {
  value = module.ec2_instance.instance-id
}

output "instance-arn" {
  value = module.ec2_instance.instance-arn
}

output "deployment-az" {
  value = module.ec2_instance.az
}
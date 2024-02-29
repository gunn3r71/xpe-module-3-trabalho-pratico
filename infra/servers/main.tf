module "ec2_instance" {
  source = "./modules/ec2"
  course_tag = var.course_tag
  image_id = var.image_id
  key_name = var.key_name
  vpc_id = var.vpc_id
  instance_type = var.instance_type
}
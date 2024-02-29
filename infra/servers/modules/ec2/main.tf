resource "aws_instance" "xpe-desafio" {
  instance_type = var.instance_type
  ami = var.image_id
  key_name = var.key_name
  vpc_security_group_ids = ["${module.security_group.sg-id}"]
  
  tags = {
    Name = "xpe-ec2-webserver-desafio-1"
    Course = var.course_tag
  }
}

module "security_group" {
  source = "./../sg"
  course_tag = var.course_tag
  env = var.env
  vpc_id = var.vpc_id
}
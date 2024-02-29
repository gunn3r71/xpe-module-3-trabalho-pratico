resource "aws_security_group" "xpe-webserver-desafio-sg" {  
    vpc_id = var.vpc_id
    tags = {
      Name = "XPe desafio m3 SG"
      Course = var.course_tag
      Env = var.env
    }
}

resource "aws_security_group_rule" "ssh_access" {
    type = "ingress"
    protocol = "tcp"
    from_port = 22
    to_port = 22
    cidr_blocks = ["0.0.0.0/0"]
    security_group_id = aws_security_group.xpe-webserver-desafio-sg.id
}

resource "aws_security_group_rule" "http_access" {
    type = "ingress"
    protocol = "tcp"
    to_port = 80
    from_port = 80
    cidr_blocks = [ "0.0.0.0/0" ]
    security_group_id = aws_security_group.xpe-webserver-desafio-sg.id
}

resource "aws_security_group_rule" "https_access" {
    type = "ingress"
    protocol = "tcp"
    to_port = 443
    from_port = 443
    cidr_blocks = [ "0.0.0.0/0" ]
    security_group_id = aws_security_group.xpe-webserver-desafio-sg.id
}

resource "aws_security_group_rule" "egress_rule" {
  type = "egress"
  protocol = "-1"
  to_port = 0
  from_port = 0
  cidr_blocks = [ "0.0.0.0/0" ]
  security_group_id = aws_security_group.xpe-webserver-desafio-sg.id
}
variable "start_instance_lambda" {
  type = map(string)
  nullable = false
  default = {
    Name = ""
    Arn = ""
    Cron = ""
  }
}

variable "stop_instance_lambda" {
  type = map(string)
  nullable = false
  default = {
    Name = ""
    Arn = ""
    Cron = ""
  }
}

variable "up_scaling_instance_lambda" {
  type = map(string)
  nullable = false
  default = {
    Name = ""
    Arn = ""
    Cron = ""
    TargetInstanceType = ""
  }
}

variable "down_scaling_instance_lambda" {
  type = map(string)
  nullable = false
  default = {
    Name = ""
    Arn = ""
    Cron = ""
    TargetInstanceType = ""
  }
}
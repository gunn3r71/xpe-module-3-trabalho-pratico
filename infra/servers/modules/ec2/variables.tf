variable "vpc_id" {
  type = string
  nullable = false
  validation {
    condition = can(regex("^vpc-", var.vpc_id))
    error_message = "The image_id value must be a valid AMI id, starting with \"ami-\"."
  }
}

variable "course_tag" {
  type = string
  nullable = false
}

variable "env" {
  type = string
  nullable = true
  default = "Study"
}

variable "image_id" {
  type = string
  nullable = false  
  validation {
    condition = can(regex("^ami-", var.image_id))
    error_message = "The image_id value must be a valid AMI id, starting with \"ami-\"."
  }
}

variable "key_name" {
  type = string
  nullable = false
}

variable "instance_type" {
  type = string
  nullable = false
}
variable "vpc_id" {
  type = string
  nullable = false
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
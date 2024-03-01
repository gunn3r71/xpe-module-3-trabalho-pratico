variable "event_rule_name" {
  type = string
  nullable = false
}

variable "lambda_schedule_expression" {
  type = string
  nullable = false
}

variable "lambda_function_name" {
  type = string
  nullable = false
}

variable "lambda_arn" {
  type = string
  nullable = false
}

variable "event_raw" {
  type = string
  nullable = true
  default = ""
}

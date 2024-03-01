resource "aws_cloudwatch_event_rule" "event_rule" {
  name = var.event_rule_name
  schedule_expression = var.lambda_schedule_expression
}

resource "aws_cloudwatch_event_target" "rule_target" {
  rule = aws_cloudwatch_event_rule.event_rule.name
  arn = var.lambda_arn
  input = jsonencode(var.event_raw)
}

resource "aws_lambda_permission" "allow_cloudwatch_to_call_lambda" {
  action = "lambda:InvokeFunction"
  function_name = var.lambda_function_name
  principal = "events.amazonaws.com"
  source_arn = aws_cloudwatch_event_rule.event_rule.arn
}
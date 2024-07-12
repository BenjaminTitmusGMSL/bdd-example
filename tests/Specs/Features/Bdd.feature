Feature: BDD Example

Scenario: Update message
	When the message is updated to be "test message"
	Then an email is sent with message "test message"

Feature: ValidateAPI
	In order to validate API access
	As a single BDD story
	I want to be told the sum of two numbers

@mytag
Scenario: Check Web Service response
	Given I have entered URUGUAY into web service request
	Then the result should contain MELILLA inside
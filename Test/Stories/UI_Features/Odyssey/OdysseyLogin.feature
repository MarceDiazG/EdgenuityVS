Feature: Login into Odyssey Portal as student
	In order to check the correct login into Odyssey
	As a student
	I want to validate the successfully login into Odyssey portal

@OdisseyStudent @Smoke @Regression
Scenario: Login Student in Odyssey
	Given Login into QA_Odyssey, Odissey Portal
	When Complete login form using marcelostudent as user
	Then check that the user is logged successfully


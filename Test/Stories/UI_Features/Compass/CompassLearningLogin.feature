Feature: Login into CompassLearning Portal
	In order to check the correct login into Compass Learning
	As a student
	I want to validate the successfully login into CL portal

@mytag
Scenario: Login Student in Compass Learning
	Given Login into QA_CompassLearning portal
	When Complete login form using marcelostudent as username
	Then check that the user is logged

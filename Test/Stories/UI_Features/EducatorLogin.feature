Feature: EducatorLogin
	In order to check Educator Login process
	As a Educator role
	I want to login in Educator Portal 

@mytag
Scenario: Succesfull Educator login
	Given Going to QA_Educator Portal
	When Login with chetanTeach and chetan credentials
	Then validate that the user was successfully logged

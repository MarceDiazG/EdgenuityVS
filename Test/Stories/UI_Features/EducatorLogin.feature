Feature: EducatorLogin
	In order to check Educator Login process
	As a Educator role
	I want to login in Educator Portal 

@mytag
Scenario: Succesfull Educator login
	Given Going to Educator Portal
	When Login with marceloTeach and marcelo
	Then validate that the user was successfully logged

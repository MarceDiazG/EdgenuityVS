Feature: EducatorLogin
	In order to check Educator Login process
	As a Educator role
	I want to login in Educator Portal 

@mytag
Scenario: Succesfull Educator login and logout
	Given Going to QA_Educator Portal
	When Login with chetanTeach and chetan credentials
	Then validate that the user was successfully logged
	When user clicks on signout link
	Then validate that user is signed out and is directed to login page.

@mytag2
Scenario: Verify 2 reviews pending for user Marcelo
	Given Going to QA_Educator Portal
	When Login with marceloTeach and marcelo credentials
	Then validate that the user was successfully logged
	And Validate 2 reviews waiting to be completed button is displayed
	When user clicks on signout link
	Then validate that user is signed out and is directed to login page.

Feature: StudentLogin
		In order to check Student Login process
		As a Student role
		I want to login in Student Portal 

@mytag
Scenario: Succesfull Student login and logout
	Given Navigate to QA_Student Portal
	When Login to Student Portal with Sunilstud and sunil credentials
	Then validate that the user was successfully logged to Portal
	When user clicks on signout link on welcome page
	Then validate that user is signed out.

@mytag2
Scenario: Verify Science Section is displayed for user Sunil
	Given Navigate to QA_Student Portal
	When Login to Student Portal with Sunilstud and sunil credentials
	Then validate that the user was successfully logged to Portal
	And Validate that Science section is displayed.
	When user clicks on signout link on welcome page
	Then validate that user is signed out.

Feature: Login Educator
	In order to check funcionality
	As a Educator user
	I want to login into Educator Portal

@Educator
Scenario: Check login of Educator
	Given Going to Educator Portal
	When I complete credentials Marceloadmin and marcelo
	Then The educator is succesfully logged

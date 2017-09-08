Feature: Basic Flow from landing page
	In order to develop an automated test efficiently
	As a first approach to BDD
	I would like to navigate on the main page of Edgeunity checking some elements

@contactPage @Smoke
Scenario:  Basic functionality on Edgeunity landing page
	Given an user that visit our landing page	
	When the user clicks on contact button
	And complete Contact Form 
	Then error message is displayed successfully

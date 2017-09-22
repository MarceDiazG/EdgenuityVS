Feature: CreationNewClassForATeacher
	In order to validate correct create class for a teacher
	As a teacher
	I want to be told the sum of two numbers

@SmokeOdyssey @SmokeOdysseyEducator
Scenario: Odyssey - Creating a Class as a Teacher
	Given Login into QA_Odyssey, Odissey Portal as Educator using qa10
	When Select My Students
	And Add a new class
	Then Verify the Class table is populated with the new class

Feature: InputFieldValidationRegistrationFormName
Name (optional, text, letters only)

Background:
Given I navigate to 'http://localhost:3000/qa-sandbox-spa'
	Then I wait load page state 'domcontentloaded'
	And I click to main menu link button by type 'NewRegistration'

@positive
Scenario: validate registration form input field name all alphabet text
	Then I enter registration details
	| Name                       | Surname     | Email                | Phone             |
	| abcdefghijklmnopqrstuvwxyz | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field name all alphabet uppercase text
	Then I enter registration details
	| Name                       | Surname     | Email                | Phone             |
	| ABCDEFGHIJKLMNOPQRSTUVWXYZ | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

#BUG
@positive
Scenario: validate registration form input field name is mandatory
	Then I enter registration details
	| Name | Surname     | Email                | Phone             |
	|      | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field should not be mandatory by name 'name'

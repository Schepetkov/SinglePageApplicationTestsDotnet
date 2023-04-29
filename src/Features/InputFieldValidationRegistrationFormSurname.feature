Feature: InputFieldValidationRegistrationFormSurname
Surname (mandatory, text, letters and numbers)

Background:
Given I navigate to 'http://localhost:3000/qa-sandbox-spa'
	Then I wait load page state 'domcontentloaded'
	And I click to main menu link button by type 'NewRegistration'

@positive
Scenario: validate registration form input field surname all alphabet text
	Then I enter registration details
	| Name | Surname                    | Email                | Phone             |
	| Dima | abcdefghijklmnopqrstuvwxyz | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field surname all alphabet uppercase text
	Then I enter registration details
	| Name | Surname                    | Email                | Phone             |
	| Dima | ABCDEFGHIJKLMNOPQRSTUVWXYZ | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field surname letters and numbers
	Then I enter registration details
	| Name | Surname               | Email                | Phone             |
	| Dima | Shchepetkov0123456789 | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field surname is mandatory
	Then I enter registration details
	| Name | Surname | Email                | Phone             |
	| Dima |         | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field should be mandatory by name 'surname'

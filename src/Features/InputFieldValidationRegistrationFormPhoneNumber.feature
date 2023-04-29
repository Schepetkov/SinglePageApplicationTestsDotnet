Feature: InputFieldValidationRegistrationFormPhoneNumber
Phone number (optional, text, numbers and + sign)

Background:
Given I navigate to 'http://localhost:3000/qa-sandbox-spa'
	Then I wait load page state 'domcontentloaded'
	And I click to main menu link button by type 'NewRegistration'

@positive
Scenario: validate registration form input field phone all alphabet text
	Then I enter registration details
	| Name | Surname     | Email                | Phone                      |
	| Dima | Shchepetkov | schepetkov@gmail.com | abcdefghijklmnopqrstuvwxyz |
	And I click to button by name 'Submit'
	Then I click to edit user credentials button
	And I validate all user filled information

@positive
Scenario: validate registration form input field phone all alphabet uppercase text
	Then I enter registration details
	| Name | Surname     | Email                | Phone                      |
	| Dima | Shchepetkov | schepetkov@gmail.com | ABCDEFGHIJKLMNOPQRSTUVWXYZ |
	And I click to button by name 'Submit'
	Then I click to edit user credentials button
	And I validate all user filled information

@positive
Scenario: validate registration form input field phone numbers
	Then I enter registration details
	| Name | Surname     | Email                | Phone       |
	| Dima | Shchepetkov | schepetkov@gmail.com | +0123456789 |
	And I click to button by name 'Submit'
	Then I click to edit user credentials button
	And I validate all user filled information

#BUG
@positive
Scenario: validate registration form input field phone is mandatory
	Then I enter registration details
	| Name | Surname     | Email                | Phone |
	| Dima | Shchepetkov | schepetkov@gmail.com |       |
	And I click to button by name 'Submit'
	Then I validate registration form input field should not be mandatory by name 'phone'

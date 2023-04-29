Feature: InputFieldValidationRegistrationFormContactEmail
Contact email (mandatory, text, letters, numbers @ + and .)

Background:
Given I navigate to 'http://localhost:3000/qa-sandbox-spa'
	Then I wait load page state 'domcontentloaded'
	And I click to main menu link button by type 'NewRegistration'

@positive
Scenario: validate registration form input field email all alphabet text
	Then I enter registration details
	| Name | Surname     | Email                                | Phone             |
	| Dima | Shchepetkov | abcdefghijklmnopqrstuvwxyz@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field email all alphabet uppercase text
	Then I enter registration details
	| Name | Surname     | Email                                | Phone             |
	| Dima | Shchepetkov | ABCDEFGHIJKLMNOPQRSTUVWXYZ@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field email numbers
	Then I enter registration details
	| Name | Surname     | Email                | Phone             |
	| Dima | Shchepetkov | 0123456789@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field email letters and numbers
	Then I enter registration details
	| Name | Surname     | Email                           | Phone             |
	| Dima | Shchepetkov | Shchepetkov0123456789@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@positive
Scenario: validate registration form input field email is mandatory
	Then I enter registration details
	| Name | Surname     | Email | Phone             |
	| Dima | Shchepetkov |       | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field should be mandatory by name 'email'

@positive
# special characters: '@' + and '.'
Scenario: validate registration form input field email contain all special characters
	Then I enter registration details
	| Name | Surname     | Email       | Phone             |
	| Dima | Shchepetkov | Shchepetkov | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field email has validation message

@positive
# special characters: '@'
Scenario: validate registration form input field email contain all special characters without address sign
	Then I enter registration details
	| Name | Surname     | Email        | Phone             |
	| Dima | Shchepetkov | Shchepetkov. | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field email has validation message

@positive
# special characters: '.'
Scenario: validate registration form input field email contain all special characters without dot
	Then I enter registration details
	| Name | Surname     | Email        | Phone             |
	| Dima | Shchepetkov | Shchepetkov@ | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field email has validation message

@positive
# special characters: '@.'
Scenario: validate registration form input field email contain all special characters, but unfinished
	Then I enter registration details
	| Name | Surname     | Email         | Phone             |
	| Dima | Shchepetkov | Shchepetkov@. | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate registration form input field email has validation message

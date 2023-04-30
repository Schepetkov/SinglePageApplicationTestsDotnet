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

#SpecialCharactersKey= ~!@#$%^&*()_+{}|:\"<>?`-=[];',./
@negative
Scenario: validate registration form input field surname with special characters
	Then I enter registration details
	#data table in SpecFlow not support this expression
	| Name | Surname              | Email                | Phone             |
	| Dima | SpecialCharactersKey | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone
#TODO: added this behavior for all not supported characters:
# single leading space
# single trailing space
# Leading and trailing spaces
# etc.

@negative
Scenario: validate registration form input field surname with a many leading spaces
	Then I enter registration details
	| Name | Surname                | Email                | Phone             |
	| Dima | Sh ch  epe t   k    ov | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@negative
Scenario: validate registration form input field surname with nonprinting character
	Then I enter registration details
	| Name | Surname                            | Email                | Phone             |
	| Dima | <b></b>-Sh-ch-epe-t-k-ov- <i> </i> | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

@negative
Scenario: validate registration form input field surname with SQL Injection
	Then I enter registration details
	| Name | Surname                                        | Email                | Phone             |
	| Dima | Select id from users where username=’username’ | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone

#BUG-08
# TODO: test will always successful because no any limit 
# redo check validation when bug will fix and form has validation message or has character limit behavior 
@negative
Scenario: validate registration form input field surname with maximum number of characters
	Then I enter registration details
	# there is no specific number in the documentation, I set random character length
	| Name | Surname                                                                                                                                                                                                                                                                                                                                       | Email                | Phone             |
	| Dima | 100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	Then I validate user details without phone
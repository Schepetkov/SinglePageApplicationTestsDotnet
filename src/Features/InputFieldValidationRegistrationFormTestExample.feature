Feature: InputFieldValidationRegistrationFormEditUserData
Validate edit user data feature

Background:
Given I navigate to 'http://localhost:3000/qa-sandbox-spa'
	Then I wait load page state 'domcontentloaded'
	And I click to main menu link button by type 'NewRegistration'
	Then I enter registration details
	| Name | Surname     | Email                | Phone             |
	| Dima | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'

@positive
Scenario: validate registration form input field edit feature
	Then I validate user details without phone
	And I click to edit user credentials button
	Then I validate all user filled information
	Then I enter registration details
	| Name     | Surname     | Email          | Phone |
	| TestName | TestSurname | Test@gmail.com | 01    |
	And I click to button by name 'Submit'
	Then I validate user details without phone

#BUG-04
@positive
Scenario: validate all user filled information
	Then I validate user details

@positive
Scenario: validate delete registration feature
	Then I validate user details without phone
	And I validate user can delete registration

@positive
Scenario: validate delete registration pop-up message behavior
	Then I validate user can close pop-up message by button name 'No'
	Then I validate user can close pop-up message by button name 'CloseCross'

#BUG-05
@positive
Scenario: validate user has unique credentials
	Then I validate user details without phone
	And I click to main menu link button by type 'NewRegistration'
	Then I enter registration details
	| Name | Surname     | Email                | Phone             |
	| Dima | Shchepetkov | schepetkov@gmail.com | +31 6 13 96 82 15 |
	And I click to button by name 'Submit'
	#TODO: Check validation message 
	Then I validate user details without phone
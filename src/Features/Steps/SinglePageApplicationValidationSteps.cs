namespace PlaywrightTests.Steps
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Playwright;
    using PlaywrightTests.Models;
    using PlaywrightTests.UI.Pages;
    using PlaywrightTests.UI.Pages.HomePage;
    using PlaywrightTests.UI.Pages.RegistrationForm;
    using PlaywrightTests.UI.Pages.RegistrationFormPage;
    using PlaywrightTests.WebDriver;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    [Binding]
    public class SinglePageApplicationValidationSteps
    {
        private readonly HomePage? homePage = null;
        private readonly RegistrationFormPage? registrationFormPage = null;
        private readonly ScenarioContext? scenarioContext = null;

        public SinglePageApplicationValidationSteps(Driver driver, ScenarioContext scenarioContext)
        {
            this.homePage = new HomePage(driver.Page);
            this.registrationFormPage = new RegistrationFormPage(driver.Page);
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to '([^']*)'")]
        public async Task NavigateTo(string url)
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToMainMenuLinkButtonByType::homePage == null");
                return;
            }

            await this.homePage.GetPage().GotoAsync(url);
        }

        [Then(@"I click to main menu link button by type '([^']*)'")]
        public async Task ClickToMainMenuLinkButtonByType(string buttonType)
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToMainMenuLinkButtonByType::homePage == null");
                return;
            }

            Enum.TryParse(buttonType, out EMainMenuLinkButtons mainMenuLinkButton);
            switch (mainMenuLinkButton)
            {
                case EMainMenuLinkButtons.Overview:
                    await this.homePage.ClickToLinkButtonByName(HomePage.Overview);
                    break;
                case EMainMenuLinkButtons.NewRegistration:
                    await this.homePage.ClickToLinkButtonByName(HomePage.NewRegistration);
                    break;
                default:
                    BasePage.StopTestWithReason($"SinglePageApplicationValidationSteps::ClickToMainMenuLinkButtonByType - incorrect main menu link button type: {buttonType}");
                    break;
            }
        }

        [Then(@"I enter registration details")]
        public async Task EnterRegistrationDetails(Table details)
        {
            var registrationFormDetails = details.CreateSet<RegistrationForm>();
            if (registrationFormDetails == null)
            {
                BasePage.StopTestWithReason("EnterRegistrationDetails::registrationFormDetails == null");
                return;
            }

            if (this.registrationFormPage == null)
            {
                BasePage.StopTestWithReason("EnterRegistrationDetails::registrationFormPage == null");
                return;
            }

            if (this.scenarioContext == null)
            {
                BasePage.StopTestWithReason("EnterRegistrationDetails::scenarioContext == null");
                return;
            }

            foreach (var field in registrationFormDetails)
            {
                if (field.Name != null)
                {
                    await this.registrationFormPage.FillFormByLocatorName(RegistrationFormPage.Name, field.Name);
                }

                if (field.Surname != null)
                {
                    await this.registrationFormPage.FillFormByLocatorName(RegistrationFormPage.Surname, field.Surname);
                    this.scenarioContext.Set<bool>(this.registrationFormPage.IsDataContainSpecialCharacters(field.Surname), HomePage.SpecialCharactersKey);
                }

                if (field.Email != null)
                {
                    await this.registrationFormPage.FillFormByLocatorName(RegistrationFormPage.Email, field.Email);
                }

                if (field.Phone != null)
                {
                    await this.registrationFormPage.FillFormByLocatorName(RegistrationFormPage.Phone, field.Phone);
                }

                bool bDataContainSpecial = this.scenarioContext.Get<bool>(HomePage.SpecialCharactersKey);
                RegistrationForm newUserCredentials = new RegistrationForm();
                newUserCredentials.Name = field.Name;
                newUserCredentials.Surname = bDataContainSpecial ? BasePage.SpecialCharactersSet : field.Surname;
                newUserCredentials.Email = field.Email;
                newUserCredentials.Phone = field.Phone;

                this.scenarioContext.Set<RegistrationForm>(newUserCredentials, HomePage.NewUserCredentials);
            }
        }

        [Then(@"I click to edit user credentials button")]
        public async Task ClickToEditUserCredentialsButton()
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToMainMenuLinkButtonByType::homePage == null");
                return;
            }

            await this.homePage.ClickToEditUserCredentialsButton();
        }

        [Then(@"I validate all user filled information")]
        public async Task ValidateUserFilledInformation()
        {
            if (this.registrationFormPage == null)
            {
                BasePage.StopTestWithReason("EnterRegistrationDetails::registrationFormPage == null");
                return;
            }

            if (this.scenarioContext == null)
            {
                BasePage.StopTestWithReason("ValidateOverviewDetails::scenarioContext == null");
                return;
            }

            RegistrationForm newUserCredential = this.scenarioContext.Get<RegistrationForm>(HomePage.NewUserCredentials);
            if (newUserCredential.Name != null)
            {
                await this.registrationFormPage.ValidateInputFieldDataByName(RegistrationFormPage.Name, newUserCredential.Name);
            }

            if (newUserCredential.Surname != null)
            {
                await this.registrationFormPage.ValidateInputFieldDataByName(RegistrationFormPage.Surname, newUserCredential.Surname);
            }

            if (newUserCredential.Email != null)
            {
                await this.registrationFormPage.ValidateInputFieldDataByName(RegistrationFormPage.Email, newUserCredential.Email);
            }

            if (newUserCredential.Phone != null)
            {
                await this.registrationFormPage.ValidateInputFieldDataByName(RegistrationFormPage.Phone, newUserCredential.Phone);
            }
        }

        [Then(@"I wait load page state '([^']*)'")]
        public async Task WaitLoadState(string stateToWaite)
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToMainMenuLinkButtonByType::homePage == null");
                return;
            }

            Enum.TryParse(stateToWaite, out LoadState state);
            await this.homePage.GetPage().WaitForLoadStateAsync(state);
        }

        [Then(@"I validate registration form input field email has validation message")]
        public async Task ValidateRegistrationFormInputFieldEmailHasValidationMessage()
        {
            if (this.registrationFormPage == null)
            {
                BasePage.StopTestWithReason("ValidateRegistrationFormInputFieldEmailHasValidationMessage::registrationFormPage == null");
                return;
            }

            await this.registrationFormPage.ValidateEmailInputFiledValidateMessage();
        }

        [Then(@"I validate user can close pop-up message by button name '([^']*)'")]
        public async Task ValidateUserCanClosePopUpMessageByButtonName(string buttonName)
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToButtonByName::homePage == null");
                return;
            }

            await this.homePage.ClickToDeleteUserCredentialsButton();

            if (buttonName == "CloseCross")
            {
                await this.homePage.ClickToCloseCrossPopUpButton();
            }
            else
            {
                await this.homePage.ClickToButtonByName(buttonName);
            }

            await this.homePage.ValidatePopUpHide();
        }

        [Then(@"I validate user can delete registration")]
        public async Task ValidateDeleteRegistrationBehavior()
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToButtonByName::homePage == null");
                return;
            }

            await this.homePage.ClickToDeleteUserCredentialsButton();
            await this.homePage.ClickToButtonByName("Yes");
            await this.homePage.ValidateOverviewEmptyState();
        }

        [Then(@"I click to button by name '([^']*)'")]
        public async Task ClickToButtonByName(string buttonName)
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ClickToButtonByName::homePage == null");
                return;
            }

            await this.homePage.ClickToButtonByName(buttonName);
        }

        [Then(@"I validate user details without phone")]
        public async Task ValidateUserDetailsWithoutPhone()
        {
            await this.ValidationUserOverviewDetails(true);
        }

        [Then(@"I validate user details")]
        public async Task ValidateUserDetails()
        {
            await this.ValidationUserOverviewDetails();
        }

        [Then(@"I validate registration form input field should be mandatory by name '([^']*)'")]
        public async Task ValidateRegistrationFormInputFieldShouldBeMandatoryByName(string fieldName)
        {
            await this.ValidateMandatoryRegistrationFormInputFieldByName(fieldName);
        }

        [Then(@"I validate registration form input field should not be mandatory by name '([^']*)'")]
        public async Task ValidateRegistrationFormInputFieldIsNotMandatoryByName(string fieldName)
        {
            await this.ValidateMandatoryRegistrationFormInputFieldByName(fieldName, true);
        }

        public async Task ValidateMandatoryRegistrationFormInputFieldByName(string fieldName, bool bNotMandatory = false)
        {
            if (this.registrationFormPage == null)
            {
                BasePage.StopTestWithReason("ValidateMandatoryRegistrationFormByName::registrationFormPage == null");
                return;
            }

            await this.registrationFormPage.ValidateMandatoryFiledByName(fieldName, bNotMandatory);
        }

        public async Task ValidationUserOverviewDetails(bool bWithoutPhone = false)
        {
            if (this.homePage == null)
            {
                BasePage.StopTestWithReason("ValidateOverviewDetails::homePage == null");
                return;
            }

            if (this.scenarioContext == null)
            {
                BasePage.StopTestWithReason("ValidateOverviewDetails::scenarioContext == null");
                return;
            }

            RegistrationForm newUserCredential = this.scenarioContext.Get<RegistrationForm>(HomePage.NewUserCredentials);
            if (newUserCredential.Name != null)
            {
                await this.homePage.ValidateUserCredentialsByFieldName(newUserCredential.Name);
            }

            if (newUserCredential.Surname != null)
            {
                await this.homePage.ValidateUserCredentialsByFieldName(newUserCredential.Surname);
            }

            if (newUserCredential.Email != null)
            {
                await this.homePage.ValidateUserCredentialsByFieldName(newUserCredential.Email);
            }

            if (newUserCredential.Phone != null && !bWithoutPhone)
            {
                await this.homePage.ValidateUserCredentialsByFieldName(newUserCredential.Phone);
            }
        }
    }
}

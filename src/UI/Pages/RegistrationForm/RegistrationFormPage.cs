namespace PlaywrightTests.UI.Pages.RegistrationFormPage
{
    using Microsoft.Playwright;

    public class RegistrationFormPage : BasePage
    {
        public RegistrationFormPage(IPage page)
            : base(page)
        {
        }

        public static string Name => "name";

        public static string Surname => "surname";

        public static string Email => "email";

        public static string Phone => "phone";

        protected string RequiredValidationLable => "*Required";

        protected string EmailInputFiledValidateMessage => "*Invalid email address";

        public async Task FillFormByLocatorName(string name, string date)
        {
            if (date == SpecialCharactersKey)
            {
                await this.GetPage().Locator($"#{name}").FillAsync(BasePage.SpecialCharactersSet);
            }
            else
            {
                await this.GetPage().Locator($"#{name}").FillAsync(date);
            }
        }

        public async Task ValidateInputFieldDataByName(string name, string date)
        {
            var inputField = this.GetPage().Locator($"#{name}");

            // Get input field value=
            var inputFieldData = await inputField.EvaluateAsync<string>("el => el.value");
            if (inputFieldData != date)
            {
                BasePage.StopTestWithReason($"ValidateInputFieldDataByName::Input field {name} has incorrect data: {inputFieldData}, should be: {date}");
            }
        }

        public async Task ValidateEmailInputFiledValidateMessage()
        {
            var locator = this.GetPage().GetByText($"{Email} {this.EmailInputFiledValidateMessage}");
            try
            {
                await Assertions.Expect(locator).ToBeVisibleAsync();
            }
            catch
            {
                BasePage.StopTestWithReason($"ValidateEmailInputFiledValidateMessage::Input field email has incorrect validation message or it doesn't show up at all");
            }
        }

        public async Task ValidateMandatoryFiledByName(string fieldName, bool bNotMandatory = false)
        {
            var locator = this.GetPage().GetByText($"{fieldName} {this.RequiredValidationLable}");

            if (bNotMandatory)
            {
                try
                {
                    await Assertions.Expect(locator).ToBeHiddenAsync();
                }
                catch
                {
                    BasePage.StopTestWithReason($"ValidateMandatoryFiledByName::Input field: {fieldName} has Required label, but it should not be mandatory field");
                }
            }
            else
            {
                try
                {
                    await Assertions.Expect(locator).ToBeVisibleAsync();
                }
                catch
                {
                    BasePage.StopTestWithReason($"ValidateMandatoryFiledByName::Input field: {fieldName} don't have Required label, it should be mandatory field");
                }
            }
        }
    }
}
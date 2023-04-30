namespace PlaywrightTests.UI.Pages.HomePage
{
    using Microsoft.Playwright;

    public class HomePage : BasePage
    {
        public HomePage(IPage page)
            : base(page)
        {
        }

        public static string NewUserCredentials => "NewUserCredentials";

        public static string Overview => "Overview";

        public static string NewRegistration => "New registration";

        public static string EmptyGridMessage => "No registration available!";

        protected static string PopUp => ".card modal__body";

        protected static string EditUserCredentialsButton => ".btn.btn--icon.-primary";

        protected static string RemoveUserCredentialsButton => ".btn.btn--icon.-secondary";

        protected static string CloseCrossPopUpButton => ".nyc-icon.nyc-icon-close-cross";

        public async Task ValidatePopUpHide()
        {
            var popUpMessage = this.GetPage().GetByText(PopUp);

            try
            {
                await Assertions.Expect(popUpMessage).ToBeHiddenAsync();
            }
            catch
            {
                BasePage.StopTestWithReason($"ValidatePopUpVisibility::PopUp should be hide");
            }
        }

        public async Task ValidateOverviewEmptyState()
        {
            var emptyCredentialsMessage = this.GetPage().GetByText(EmptyGridMessage);

            try
            {
                await Assertions.Expect(emptyCredentialsMessage).ToBeVisibleAsync();
            }
            catch
            {
                BasePage.StopTestWithReason($"ValidateEmptyGridMessage::Message '{EmptyGridMessage}' not present in overview");
            }
        }

        public async Task ClickToEditUserCredentialsButton()
        {
            await this.GetPage().Locator(EditUserCredentialsButton).ClickAsync();
        }

        public async Task ClickToCloseCrossPopUpButton()
        {
            await this.GetPage().Locator(CloseCrossPopUpButton).Last.ClickAsync();
        }

        public async Task ClickToDeleteUserCredentialsButton()
        {
            await this.GetPage().Locator(RemoveUserCredentialsButton).ClickAsync();
        }

        public async Task ValidateUserCredentialsByFieldName(string fieldName)
        {
            var userCredentialsCell = this.GetPage().GetByRole(AriaRole.Cell, new () { Name = fieldName, Exact = true });

            try
            {
                await Assertions.Expect(userCredentialsCell).ToBeVisibleAsync();
            }
            catch
            {
                BasePage.StopTestWithReason($"ValidateUserCredentialsByFieldName::Data '{fieldName}' not present in overview details");
            }
        }
    }
}
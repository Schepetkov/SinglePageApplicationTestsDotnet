namespace PlaywrightTests.UI.Pages
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Playwright;

    public class BasePage
    {
        private readonly IPage page;

        public BasePage(IPage page) => this.page = page;

        public static string EnterButtonName => "Enter";

        public static void StopTestWithReason(string reason)
        {
            var bTestFail = true;
            bTestFail.Should().BeFalse($"{reason}");
        }

        public IPage GetPage() => this.page;

        public async Task ClickToButtonByName(string buttonName)
        {
            await this.GetPage().GetByRole(AriaRole.Button, new () { Name = buttonName, Exact = true }).ClickAsync();
        }

        public async Task ClickToLinkButtonByName(string buttonName)
        {
            await this.GetPage().GetByRole(AriaRole.Link, new () { Name = buttonName, Exact = true }).ClickAsync();
        }
    }
}
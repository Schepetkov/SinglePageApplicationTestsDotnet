namespace PlaywrightTests.UI.Pages
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Playwright;

    public class BasePage
    {
        private readonly IPage page;

        public BasePage(IPage page) => this.page = page;

        // data table in SpecFlow not support this
        public static string SpecialCharactersSet => " ~!@#$%^&*()_+{}|:\"<>?`-=[];',./";

        public static string SpecialCharactersKey => "SpecialCharactersKey";

        public static void StopTestWithReason(string reason)
        {
            var bTestFail = true;
            bTestFail.Should().BeFalse($"{reason}");
        }

        public IPage GetPage() => this.page;

        public bool IsDataContainSpecialCharacters(string data)
        {
            return data == SpecialCharactersKey;
        }

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
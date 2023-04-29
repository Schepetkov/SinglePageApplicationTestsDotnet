namespace PlaywrightTests.WebDriver
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Playwright;

    public class Driver : IDisposable
    {
        private readonly Task<IPage> page;
        private IBrowser browser;

        public Driver() => this.page = Task.Run(this.InitializePlaywright);

        public IPage Page => this.page.Result;

        public void Dispose() => this.browser?.CloseAsync();

        private async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();

            this.browser = await playwright.Chromium.LaunchAsync(new ()
            {
                // delete comment if you want to observe how the test executes scenarios
                // Headless = false,
                // SlowMo = 100,
            });

            return await this.browser.NewPageAsync();
        }
    }
}
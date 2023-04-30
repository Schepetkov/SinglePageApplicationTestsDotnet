using System.Management.Automation;
using TechTalk.SpecFlow;
using Xunit;

[assembly: CollectionBehavior(MaxParallelThreads = 6)]

namespace PlaywrightTests.Hooks
{
    [Binding]
    internal class HooksInitializer
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // The better way to do it via a separate job in CI/CD pipeline
            PowerShell ps = PowerShell.Create();
            ps.AddScript("docker run -d -it -p 3000:3000 qa-sandbox").Invoke();
            Thread.Sleep(3000);
            ps.Stop();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript("docker stop $(docker ps -a -q)").Invoke();
            ps.Stop();
        }
    }
}

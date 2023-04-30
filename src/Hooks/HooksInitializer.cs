using TechTalk.SpecFlow;
using Xunit;

[assembly: CollectionBehavior(MaxParallelThreads = 6)]

namespace PlaywrightTests.Hooks
{
    [Binding]
    internal class HooksInitializer
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            // TODO: execute command via WPS
            // docker run -it -p 3000:3000 qa-sandbox
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // TODO: execute command via WPS
            // docker stop <container name>
        }
    }
}

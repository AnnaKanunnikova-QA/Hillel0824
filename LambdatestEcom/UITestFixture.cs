using Microsoft.Playwright;

namespace LambdatestEcom
{
    public class UITestFixture
    {
        public IPage page { get; private set; }
        private IBrowser browser;
        protected IBrowserContext context;
        protected const string StateFilePath = "../../../playwright/.auth/state.json";

        [SetUp]
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = ciEnv == "true",

            });

            // Ensure state directory and file exist
            var stateDirectory = Path.GetDirectoryName(StateFilePath);
            if (!Directory.Exists(stateDirectory))
            {
                Directory.CreateDirectory(stateDirectory);
            }

            if (!File.Exists(StateFilePath))
            {
                await File.WriteAllTextAsync(StateFilePath, "{}");
            }

            // Load state when creating context
            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                StorageStatePath = StateFilePath
            });

            page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}

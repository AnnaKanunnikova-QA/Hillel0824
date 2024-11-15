using Microsoft.Playwright;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class WebTablesTest
{
    [Test]
    public async Task DeleteRow()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".rt-tr-group")
            .Filter(new() { Has = page.GetByRole(AriaRole.Gridcell, new() { Name = "Alden", Exact = true }) })
            .GetByTitle("Delete").ClickAsync();
        await Assertions.Expect(page.GetByText("Alden")).Not.ToBeVisibleAsync();
    }

    [Test]
    public async Task EditLastNameandSallary()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".row > div:nth-child(3)").ClickAsync();
          await page.Locator("#edit-record-2 path").ClickAsync();
        await page.GetByPlaceholder("Last Name").ClickAsync();
        await page.GetByPlaceholder("Last Name").FillAsync("Cantrell edit");
        await page.GetByPlaceholder("Salary").FillAsync("15000");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Assertions.Expect(page.Locator(".col-12 > div:nth-child(4)")).ToBeVisibleAsync();


        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("Cantrell edit");

        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("15000");
    }

    [Test]
    public async Task AddNewRecord()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demoqa.com/webtables");
        await page.Locator(".row > div:nth-child(3)").ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
        await page.GetByPlaceholder("First Name").ClickAsync();
        await page.GetByPlaceholder("First Name").FillAsync("Anna");
        await page.GetByPlaceholder("Last Name").FillAsync("Kanunnikova");
        await page.GetByPlaceholder("name@example.com").FillAsync("avkanunnikova@gmail.com");
        await page.GetByPlaceholder("Age").ClickAsync();
        await page.GetByPlaceholder("Age").FillAsync("30");
        await page.GetByPlaceholder("Salary").ClickAsync();
        await page.GetByPlaceholder("Salary").FillAsync("5500");
        await page.GetByPlaceholder("Department").FillAsync("QA");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("Anna");
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("Kanunnikova");
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("avkanunnikova@gmail.com");
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("5500");
        await Assertions.Expect(page.GetByRole(AriaRole.Grid)).ToContainTextAsync("QA");


    }

}
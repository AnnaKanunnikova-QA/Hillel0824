using Microsoft.Playwright;

namespace LambdatestEcom.Tests
{
    internal class LoginThroughApi : UITestFixture
    {
        [Test]
        public async Task LoginTest()
        {

            // Arrange
            var email = "ak@test.com"; // Replace with a pre-created valid user email
            var password = "123123"; // Replace with the correct password

            var loginData = context.APIRequest.CreateFormData();
            loginData.Append("email", email);
            loginData.Append("password", password);

            // Act
            var response = await context.APIRequest.PostAsync(
                "https://ecommerce-playground.lambdatest.io/index.php?route=account/login",
                new() { Form = loginData }
            );

            // Assert API Response
            Assert.That(response.Ok, Is.True, "The login API call failed.");
            Assert.That(response.Status, Is.EqualTo(200), "The login API response returned a non-200 status.");

            // Navigate to account page to verify login
            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");

            // Assert UI to confirm user is logged in
            var accountHeader = page.Locator("h2:has-text('My Account')");
            await Assertions.Expect(accountHeader).ToBeVisibleAsync();

            Console.WriteLine("Test passed: The user is logged in, and the account page is displayed.");
        }

        [Test]
        public async Task VerifyUserIsLoggedIn()
        {
            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=common/home");

            // Check if user is logged in
            var accountMenu = page.GetByRole(AriaRole.Button, new() { Name = "My account" });
            await accountMenu.HoverAsync(); // Ensure dropdown is visible

            // Wait for the "Login" link to appear in the dropdown
            var loginLink = page.Locator("a[href*='route=account/login']");

            // Check if the "Login" link is visible
            if (await loginLink.IsVisibleAsync())
            {

                // User is not logged in; perform login via UI
                await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/login");
                await page.GetByPlaceholder("E-Mail Address").FillAsync("ak@test.com");
                await page.GetByPlaceholder("Password").FillAsync("123123");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                // Save state
                await context.StorageStateAsync(new ()
                {
                    Path = StateFilePath
                });
            }

            // Navigate to account page to verify login
            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");

            // Assert UI to confirm user is logged in
            var accountHeader = page.Locator("h2:has-text('My Account')");
            await Assertions.Expect(accountHeader).ToBeVisibleAsync();
        }
    }
}


       
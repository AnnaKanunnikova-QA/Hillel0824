using OpenQA.Selenium;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests

{
    public class TextBoxTests: BaseClass
    {

        By userNameBy = By.Id("userName");
        By userEmailBy = By.Id("userEmail");
        By currentAddressBy = By.Id("currentAddress");
        By permanentAddressBy = By.Id("permanentAddress");
        By submitBy = By.Id("submit");




        [Test]
        public void FillAndSubmitTest()
        {
            var formPage = new FormPage(_driver);
            formPage.NavigateTo("https://demoqa.com/text-box");


            // Fill out the user name field
            formPage.FillInput(userNameBy, "Anna Kanunnikova");
            // Fill out the emailfield
            formPage.FillInput(userEmailBy, "avkanunnikova@gmail.com");
            // Fill out the Current Address
            formPage.FillInput(currentAddressBy, "Funchal, Madeira");
            // Fill out the Permanent Address
            formPage.FillInput(permanentAddressBy,  "California, USA");
            // Click Submit button
            formPage.ClickElement(submitBy);

            var resultName = _driver.FindElement(By.Id("name"));
            Assert.That(resultName.Text, Is.EqualTo("Name:Anna Kanunnikova"));
            var resultEmail = _driver.FindElement(By.Id("email"));
            Assert.That(resultEmail.Text, Is.EqualTo("Email:avkanunnikova@gmail.com"));
            var resultCurrentAddress = _driver.FindElement(By.CssSelector("#output  #currentAddress"));
            Assert.That(resultCurrentAddress.Text, Is.EqualTo("Current Address :Funchal, Madeira"));
            var resultPermanentAddress = _driver.FindElement(By.CssSelector("#output  #permanentAddress"));
            Assert.That(resultPermanentAddress.Text, Is.EqualTo("Permananet Address :California, USA"));
        }

    }
}














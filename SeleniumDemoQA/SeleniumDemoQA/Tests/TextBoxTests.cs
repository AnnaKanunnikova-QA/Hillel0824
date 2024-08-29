using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;

namespace SeleniumDemoQA.Tests
{
    internal class TextBoxTests
    {
        private IWebDriver _driver;
        IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://demoqa.com/text-box ");
            _js = (IJavaScriptExecutor)_driver;
        }
        private void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        void FillInput(By selector, string value)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.SendKeys(value);
        }
        private void ClickElement(By selector)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.Click();
        }

        [Test]
        public void FillAndSubmitTest()
        {

            // Fill out the user name field
            FillInput(By.Id("userName"), "Anna Kanunnikova");
            // Fill out the emailfield
            FillInput(By.Id("userEmail"), "avkanunnikova@gmail.com");
            // Fill out the Current Address
            FillInput(By.Id("currentAddress"), "Funchal, Madeira");
            // Fill out the Permanent Address
            FillInput(By.Id("permanentAddress"),  "California, USA");
            // Click Submit button
            ClickElement(By.Id("submit"));

            var resultName = _driver.FindElement(By.Id("name"));
            Assert.That(resultName.Text, Is.EqualTo("Name:Anna Kanunnikova"));
            var resultEmail = _driver.FindElement(By.Id("email"));
            Assert.That(resultName.Text, Is.EqualTo("Email:avkanunnikova@gmail.com"));
            var resultCurrentAddress = _driver.FindElement(By.Id("currentAddress"));
            Assert.That(resultName.Text, Is.EqualTo("Current Address :Funchal, Madeira"));
            var resultPermanentAddress = _driver.FindElement(By.Id("permanentAddress"));
            Assert.That(resultName.Text, Is.EqualTo("Permanent Address :California, USA"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}














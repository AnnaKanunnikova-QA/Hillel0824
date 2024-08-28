using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests
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
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            _js = (IJavaScriptExecutor)_driver;
        }

        private void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
          
        private void FillInput(By selector, string value)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.SendKeys(value);
        }

        private void FillInputAndEnter(By selector, string value)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.SendKeys(value);
            webElement.SendKeys(Keys.Enter);
        }


        private void ClickElement(By selector)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.Click();
        }
        private void ClickWithoutScroll(By selector)
        {
            var webElement = _driver.FindElement(selector);
            webElement.Click();
        }
        private void SelectText(By selector, string text)
        {
            var webElement = new SelectElement(_driver.FindElement(selector));
            webElement.SelectByText(text);
        }

        private string GetGss(string id)
        {
            var webElement = _driver.FindElement(By.Id(id));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            return webElement.GetCssValue("border-color");
        }


        [Test]
        public void FillAndSubmitFormTest()
        {
            FillInput(By.Id("firstName"), "John");
            FillInput(By.Id("lastName"), "Doe");

            // Scroll to Email and fill it out
            FillInput(By.Id("userEmail"), "johndoe@example.com");

            ClickElement(By.CssSelector("label[for='gender-radio-1']"));

            // Scroll to Mobile Number and fill it out
            FillInput(By.Id("userNumber"), "1234567890");

            // Scroll to Date of Birth and set it
            ClickElement(By.Id("dateOfBirthInput"));

            SelectText(By.ClassName("react-datepicker__month-select"), "May");

            SelectText(By.ClassName("react-datepicker__year-select"), "1990");

            ClickWithoutScroll(By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)"));

            // Scroll to Subjects and fill it out
            FillInputAndEnter(By.Id("subjectsInput"), "Maths");

            // Scroll to Hobbies and select one
            ClickElement(By.CssSelector("label[for='hobbies-checkbox-1']"));


            // Scroll to Current Address and fill it out
            FillInput(By.Id("currentAddress"), "123 Main Street, Anytown, USA");


            // Scroll to State dropdown and select a state
            ClickElement(By.Id("state"));
            // need separate method
            ClickWithoutScroll(By.XPath("//div[text()='NCR']"));

            // Scroll to City dropdown and select a city
            ClickElement(By.Id("city"));
            // need separate method
            ClickWithoutScroll(By.XPath("//div[text()='Delhi']"));
            // Scroll to Submit button and click it
            ClickElement(By.Id("submit"));

            // Validate the Form Submission (e.g., check for the confirmation modal)
            var confirmationModal = _driver.FindElement(By.Id("example-modal-sizes-title-lg"));
            Assert.IsTrue(confirmationModal.Displayed);
            Assert.AreEqual("Thanks for submitting the form", confirmationModal.Text);
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            var js = (IJavaScriptExecutor)_driver;

            // Scroll to and click the Submit button without filling any field
            ClickElement(By.Id("submit"));

            // Scroll to and verify validation for First Name // need separate method
            string firstNameBorderColor = GetGss("firstName");

            // Scroll to and verify validation for Last Name
            string lastNameBorderColor = GetGss("lastName");

            // Scroll to and verify validation for Email
            string emailBorderColor = GetGss("userEmail");



            // Scroll to and verify validation for Mobile Number
            string mobileNumberBorderColor = GetGss("userNumber");




            // Check if the border color indicates an error (commonly red)
            string expectedBorderColor = "rgb(220, 53, 69)"; // Adjust this if the page uses a different color
            string expectedEmailColor = "rgb(40, 167, 69)";

            Assert.AreEqual(expectedBorderColor, firstNameBorderColor, "First Name validation failed.");
            Assert.AreEqual(expectedBorderColor, lastNameBorderColor, "Last Name validation failed.");
            Assert.AreEqual(expectedEmailColor, emailBorderColor, "Email validation failed.");
            Assert.AreEqual(expectedBorderColor, mobileNumberBorderColor, "Mobile Number validation failed.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

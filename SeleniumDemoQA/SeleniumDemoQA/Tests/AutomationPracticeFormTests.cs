using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Pages;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests: BaseClass
    {
        public bool? IsConfirmationModalDisplayed { get; private set; }

        [Test]
        public void FillAndSubmitFormTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            var formPage = new FormPage(_driver);


            //formPage.FillInput(By.Id("firstName"), "John");
            formPage.FillInputById("firstName", "John");

            formPage.FillInputById("lastName", "Doe");

            // Scroll to Email and fill it out
            formPage.FillInputById("userEmail", "johndoe@example.com");

            formPage.ClickElementBySelector("label[for='gender-radio-1']");

            // Scroll to Mobile Number and fill it out
            formPage.FillUserNumber("1234567890");

            // Scroll to Date of Birth and set it
            formPage.ClickElementById("dateOfBirthInput");

            formPage.SelectTextByClassName("react-datepicker__month-select","May");

            formPage.SelectTextByClassName("react-datepicker__year-select", "1990");

            formPage.ClickElementByCssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)");

            // Scroll to Subjects and fill it out
            formPage.FillInpuctAndEnterByClassNameId("subjectsInput", "Maths");

            // Scroll to Hobbies and select one
            formPage.ClickElementByCssSelector("label[for='hobbies-checkbox-1']");


            // Scroll to Current Address and fill it out
            formPage.FillInputById("currentAddress", "123 Main Street, Anytown, USA");


            // Scroll to State dropdown and select a state
            formPage.ClickElementById("state");
            
            // need separate method
            formPage.ClickElementByXPath("//div[text()='NCR']");

            // Scroll to City dropdown and select a city
            formPage.ClickElementById("city");
            // need separate method

            formPage.ClickElementByXPath("//div[text()='Delhi']");
            // Scroll to Submit button and click it
            formPage.ClickElementById("submit");

            // Validate the Form Submission (e.g., check for the confirmation modal)
            //var confirmationModal = _driver.FindElement(By.Id("example-modal-sizes-title-lg"));
            var isConfirmationModalDisplayed = formPage.IsConfirmationModalDisplayed();
            var confirmationModalText = formPage.GetConfirmationModalText();

            //Assert.IsTrue(confirmationModal.Displayed);
            Assert.IsTrue(isConfirmationModalDisplayed);
            //Assert.AreEqual("Thanks for submitting the form", confirmationModal.Text);
            Assert.That(confirmationModalText, Is.EqualTo("Thanks for submitting the form"));
        }


        [Test]
        public void VerifyFormValidationTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

            var formPage = new FormPage(_driver);

            // Scroll to and click the Submit button without filling any field
            formPage.ClickElementById("submit");

            // Scroll to and verify validation for First Name // need separate method
            string firstNameBorderColor = formPage.GetBorderColor("firstName");

            // Scroll to and verify validation for Last Name
            string lastNameBorderColor = formPage.GetBorderColor("lastName");

            // Scroll to and verify validation for Email
            string emailBorderColor = formPage.GetBorderColor("userEmail");



            // Scroll to and verify validation for Mobile Number
            string mobileNumberBorderColor = formPage.GetBorderColor("userNumber");

            // Check if the border color indicates an error (commonly red)
            string expectedBorderColor = "rgb(220, 53, 69)"; // Adjust this if the page uses a different color
            string expectedEmailColor = "rgb(40, 167, 69)";

            Assert.AreEqual(expectedBorderColor, firstNameBorderColor, "First Name validation failed.");
            Assert.AreEqual(expectedBorderColor, lastNameBorderColor, "Last Name validation failed.");
            Assert.AreEqual(expectedEmailColor, emailBorderColor, "Email validation failed.");
            Assert.AreEqual(expectedBorderColor, mobileNumberBorderColor, "Mobile Number validation failed.");
        }
    }
}

using OpenQA.Selenium;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests : BaseClass
    {
        By firstNameBy = By.Id("firstName");
        By lastNameBy = By.Id("lastName");
        By userEmailBy = By.Id("userEmail");
        By genderRadioBy = By.CssSelector("label[for='gender-radio-1']");
        By usernamberBy = By.Id ("userNumber");
        By dateOfBirthInputBy = By.Id("dateOfBirthInput");
        By datepickerMonthBy = By.ClassName("react-datepicker__month-select");
        By datepickerYearBy = By.ClassName("react-datepicker__year-select");
        By datepickerDayBy = By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)");
        By subjectsInputBy = By.Id("subjectsInput");
        By hobbiesCheckboxBy = By.CssSelector("label[for='hobbies-checkbox-1']");
        By currentAddressBy = By.Id("currentAddress");
        By stateBy = By.Id("state");
        By divTextNCRBy = By.XPath("//div[text()='NCR']");
        By cityBy = By.Id("city");
        By divTextDelhiBy = By.XPath("//div[text()='Delhi']");
        By submitBy = By.Id("submit");

        [Test]

        public void FillAndSubmitFormTest()
        {
            var formPage = new FormPage(_driver);
            formPage.NavigateTo("https://demoqa.com/automation-practice-form");


            formPage.FillInput(firstNameBy, "John");

            formPage.FillInput(lastNameBy, "Doe");

            // Scroll to Email and fill it out
            formPage.FillInput(userEmailBy, "johndoe@example.com");

            formPage.ClickElement(genderRadioBy);

            // Scroll to Mobile Number and fill it out
            formPage.FillInput(usernamberBy, "1234567890");

            // Scroll to Date of Birth and set it
            formPage.ClickElement(dateOfBirthInputBy);

            formPage.SelectByText(datepickerMonthBy, "May");

            formPage.SelectByText(datepickerYearBy, "1990");

            formPage.ClickElement(datepickerDayBy);

            // Scroll to Subjects and fill it out
            formPage.FillInputAndEnter(subjectsInputBy, "Maths");

            // Scroll to Hobbies and select one
            formPage.ClickWithoutScroll(hobbiesCheckboxBy);

            // Scroll to Current Address and fill it out
            formPage.FillInput(currentAddressBy, "123 Main Street, Anytown, USA");


            // Scroll to State dropdown and select a state
            formPage.ClickElement(stateBy);
            
            // need separate method
            formPage.ClickElement(divTextNCRBy);

            // Scroll to City dropdown and select a city
            formPage.ClickElement(cityBy);
            // need separate method

            formPage.ClickElement(divTextDelhiBy);
            // Scroll to Submit button and click it
            formPage.ClickElement(submitBy);

            // Validate the Form Submission (e.g., check for the confirmation modal)
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
            var formPage = new FormPage(_driver);
            formPage.NavigateTo("https://demoqa.com/automation-practice-form");


            // Scroll to and click the Submit button without filling any field
            formPage.ClickElement(submitBy);

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

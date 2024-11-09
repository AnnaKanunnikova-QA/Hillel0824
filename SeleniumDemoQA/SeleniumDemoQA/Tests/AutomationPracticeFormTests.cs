using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests
{
    public class AutomationPracticeFormTests : BaseClass
    {
        [Test]

        public void FillAndSubmitFormTest()
        {
            var formPage = new FormPage(_driver);
            formPage.OpenWebPage();


            formPage.FillFirstName("John");

            formPage.FillLastName("Doe");

            // Scroll to Email and fill it out
            formPage.FillEmail("johndoe@example.com");

            formPage.ClickGenderRadio();

            // Scroll to Mobile Number and fill it out
            formPage.FillMobileNumber("1234567890");

            // Scroll to Date of Birth and set it
            formPage.ClickDateOfBirth();

            formPage.SelectMonth("May");

            formPage.SelectYear("1990");

            formPage.SelectDate();

            // Scroll to Subjects and fill it out
            formPage.FillSubject("Maths");

            // Scroll to Hobbies and select one
            formPage.ClickHobbies();

            // Scroll to Current Address and fill it out
            formPage.FillCurrentAddress("123 Main Street, Anytown, USA");


            // Scroll to State dropdown and select a state
            formPage.ClickState();
            
            formPage.ClickNCR();

            // Scroll to City dropdown and select a city
            formPage.ClickCity();

            formPage.ClickDelhi();
            // Scroll to Submit button and click it
            formPage.ClickSubmint();

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
            formPage.OpenWebPage();


            // Scroll to and click the Submit button without filling any field
            formPage.ClickSubmint();

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

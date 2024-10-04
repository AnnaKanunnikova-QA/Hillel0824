using OpenQA.Selenium;
using SeleniumDemoQA.Pages;

namespace SeleniumDemoQA.Tests

{
    public class TextBoxTests : BaseClass
    {

        [Test]
        public void FillAndSubmitTest()
        {

            //Arrange
            var textBoxPage = new TextBoxPage(_driver);
            textBoxPage.NavigateTo("https://demoqa.com/text-box");

            //Act

            // Fill out the user name field
            textBoxPage.FillFullName("Anna Kanunnikova");
            // Fill out the emailfield
            textBoxPage.FillEmail("avkanunnikova@gmail.com");
            // Fill out the Current Address
            textBoxPage.FillcurrentAddressBy("Funchal, Madeira");
            // Fill out the Permanent Address
            textBoxPage.FillpermanentAddressBy("California, USA");
            // Click Submit button
            textBoxPage.SubmitForm();

            //Asssert
            Assert.Multiple(() =>
            {

                Assert.That(textBoxPage.GetOutputName(), Is.EqualTo("Name:Anna Kanunnikova"));

                Assert.That(textBoxPage.GetOutputEmail, Is.EqualTo("Email:avkanunnikova@gmail.com"));
                // var resultCurrentAddress = _driver.FindElement(currentOutputAddressBy);
                Assert.That(textBoxPage.GetOutputCurrentAddressBy, Is.EqualTo("Current Address :Funchal, Madeira"));
                //var resultPermanentAddress = _driver.FindElement(permantAddressBy);
                Assert.That(textBoxPage.GetOutputPermanentAddress, Is.EqualTo("Permananet Address :California, USA"));
            })
;
    }
    } }














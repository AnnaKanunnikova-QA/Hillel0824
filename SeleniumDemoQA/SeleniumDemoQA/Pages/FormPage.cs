using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage : BasePage
    {

        private By confirmationModalElement = By.Id("example-modal-sizes-title-lg");
        private By firstNameInputBy = By.Id("firstName");
        private By lastNameInputBy = By.Id("lastName");
        private By emailInputBy = By.Id("userEmail");
        private By mobileNumberInputBy = By.Id("userNumber");
        private By currentAddressInputBy = By.Id("currentAddress");
        private By dateOfBirthInputBy = By.Id("dateOfBirthInput");
        private By monthPickerBy = By.ClassName("react-datepicker__month-select");
        private By yearPickerBy = By.ClassName("react-datepicker__year-select");
        private By subjectsInputBy = By.Id("subjectsInput");
        private By stateDropdownBy = By.Id("state");
        private By cityDropdownBy = By.Id("city");
        private By submitButtonBy = By.Id("submit");
        private By confirmationModalBy = By.Id("example-modal-sizes-title-lg");

        public FormPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void FillFirstName(string firstName)
        {
            FillInput(firstNameInputBy, firstName);
        }

        public void FillLastName(string lastName)
        {
            FillInput(lastNameInputBy, lastName);
        }

        public void FillEmail(string email)
        {
            FillInput(emailInputBy, email);
        }

        public void FillMobileNumber(string mobileNumber)
        {
            FillInput(mobileNumberInputBy, mobileNumber);
        }

        public void FillSubject(string subject)
        {
            FillInput(subjectsInputBy, subject);
            FindElement(subjectsInputBy).SendKeys(Keys.Enter);
        }

        public void FillCurrentAddress(string currentAddress)
        {
            FillInput(currentAddressInputBy, currentAddress);
        }


        public void SelectByText(By selector, string text)
        {
            var webElement = new SelectElement(_driver.FindElement(selector));
            webElement.SelectByText(text);
        }

        public string GetBorderColor(string id)
        {
            var webElement = _driver.FindElement(By.Id(id));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            return webElement.GetCssValue("border-color");
        }

        internal bool IsConfirmationModalDisplayed()
        {
            return _driver.FindElement(confirmationModalElement).Displayed;
        }

            internal string GetConfirmationModalText()

        {

            return _driver.FindElement(confirmationModalElement).Text;
        }

        public void SubmitForm()
        {
            ClickElement(submitButtonBy);
        }

    }
}

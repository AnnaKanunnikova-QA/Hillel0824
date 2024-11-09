using OpenQA.Selenium;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage : BasePage
    {

        private By confirmationModalElement = By.Id("example-modal-sizes-title-lg");
        private By firstNameInputBy = By.Id("firstName");
        private By lastNameInputBy = By.Id("lastName");
        private By emailInputBy = By.Id("userEmail");
        private By genderRadioBy = By.CssSelector("label[for='gender-radio-1']");
        private By mobileNumberInputBy = By.Id("userNumber");
        private By dateOfBirthInputBy = By.Id("dateOfBirthInput");
        private By monthPickerBy = By.ClassName("react-datepicker__month-select");
        private By yearPickerBy = By.ClassName("react-datepicker__year-select");
        private By datepickerDayBy = By.CssSelector(".react-datepicker__day--015:not(.react-datepicker__day--outside-month)");
        private By subjectsInputBy = By.Id("subjectsInput");
        private By hobbiesCheckboxBy = By.CssSelector("label[for='hobbies-checkbox-1']");
        private By currentAddressInputBy = By.Id("currentAddress");
        private By stateBy = By.Id("state");
        private By divTextNCRBy = By.XPath("//div[text()='NCR']");
        private By cityBy = By.Id("city");
        private By divTextDelhiBy = By.XPath("//div[text()='Delhi']");
        private By submitBy = By.Id("submit");
        private string pageUrl = "https://demoqa.com/automation-practice-form ";

        public FormPage(IWebDriver driver) : base(driver)
        {
            
        }

        public void FillFirstName(string firstName)
        {
            _driver.FillInput(firstNameInputBy, firstName);
        }

        public void FillLastName(string lastName)
        {
            _driver.FillInput(lastNameInputBy, lastName);
        }

        public void FillEmail(string email)
        {
            _driver.FillInput(emailInputBy, email);
        }

        public void ClickGenderRadio()
        {
            _driver.ClickElement(genderRadioBy);
        }

        public void FillMobileNumber(string mobileNumber)
        {
            _driver.FillInput(mobileNumberInputBy, mobileNumber);
        }

        public void ClickDateOfBirth()
        {
            _driver.ClickElement(dateOfBirthInputBy);
        }

        public void SelectMonth(string month)
        {
            _driver.SelectByText(monthPickerBy, month);

        }

        public void SelectYear(string year)
        {
            _driver.SelectByText(yearPickerBy, year);
        }

        public void SelectDate()
        {
            _driver.ClickElement(datepickerDayBy);
        }

        public void FillSubject(string subject)
        {
            _driver.FillInput(subjectsInputBy, subject);
            _driver.FindElement(subjectsInputBy).SendKeys(Keys.Enter);
        }

        public void ClickHobbies()
        {
            _driver.ClickWithoutScroll(hobbiesCheckboxBy);
        }

        public void FillCurrentAddress(string currentAddress)
        {
            _driver.FillInput(currentAddressInputBy, currentAddress);
        }

        public void ClickState()
        {
            _driver.ClickElement(stateBy);
        }

        public void ClickNCR()
        {
            _driver.ClickElement(divTextNCRBy);
        }

        public void ClickCity()
        {
            _driver.ClickElement(cityBy);
        }

        public void ClickDelhi()
        {
            _driver.ClickElement(divTextDelhiBy);
        }
        public void ClickSubmint()
        {
            _driver.ClickElement(submitBy);
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

        public void OpenWebPage()
        {
            _driver.NavigateTo(pageUrl);
        }

    }
}

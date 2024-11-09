using OpenQA.Selenium;

namespace SeleniumDemoQA.Pages
{
    internal class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver) : base(driver)
        {

        }

        private string pageUrl = "https://demoqa.com/text-box";
        private By userNameBy = By.Id("userName");
        private By userEmailBy = By.Id("userEmail");
        private By currentAddressBy = By.Id("currentAddress");
        private By permanentAddressBy = By.Id("permanentAddress");
        private By submitBy = By.Id("submit");
        private By nameOutputBy = By.Id("name");
        private By emailOutputBy = By.Id("email");
        private By currentOutputAddressBy = By.CssSelector("#output  #currentAddress");
        private By permantOutputAddressBy = By.CssSelector("#output  #permanentAddress");
        private By submitButtonBy = By.Id("submit");

        public void FillFullName(string userName)
        {
            _driver.FillInput(userNameBy, userName);
        }

        public void FillEmail(string userEmail)
        {
            _driver.FillInput(userEmailBy, userEmail);
        }
        public void FillcurrentAddressBy(string currentAddress)
        {
            _driver.FillInput(currentAddressBy, currentAddress);
        }
    
        public void FillpermanentAddressBy(string permanentAddress)
        {
            _driver.FillInput(permanentAddressBy, permanentAddress);
        }

        public void SubmitForm()
        {
            _driver.ClickElement(submitButtonBy);
        }

        public String GetOutputName()
        {
            return _driver.FindElement(nameOutputBy).Text;
        }

        public String GetOutputEmail()
        {
            return _driver.FindElement(emailOutputBy).Text;
        }

        public String GetOutputCurrentAddressBy()
        {
            return _driver.FindElement(currentOutputAddressBy).Text;
        }

        public String GetOutputPermanentAddress()
        {
            return _driver.FindElement(permantOutputAddressBy).Text;
        }

        public void OpenWebPage()
        {
            _driver.NavigateTo(pageUrl);
        }
    }

}

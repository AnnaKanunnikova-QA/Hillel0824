using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver) : base(driver)
        {

        }

        By userNameBy = By.Id("userName");
        By userEmailBy = By.Id("userEmail");
        By currentAddressBy = By.Id("currentAddress");
        By permanentAddressBy = By.Id("permanentAddress");
        By submitBy = By.Id("submit");
        By nameOutputBy = By.Id("name");
        By emailOutputBy = By.Id("email");
        By currentOutputAddressBy = By.CssSelector("#output  #currentAddress");
        By permantOutputAddressBy = By.CssSelector("#output  #permanentAddress");
        By submitButtonBy = By.Id("submit");

        public void FillFullName(string userName)
        {
            FillInput(userNameBy, userName);
        }

        public void FillEmail(string userEmail)
        {
            FillInput(userEmailBy, userEmail);
        }
        public void FillcurrentAddressBy(string currentAddress)
        {
            FillInput(currentAddressBy, currentAddress);
        }
    
        public void FillpermanentAddressBy(string permanentAddress)
        {
            FillInput(permanentAddressBy, permanentAddress);
        }

        public void SubmitForm()
        {
            ClickElement(submitButtonBy);
        }

        public String GetOutputName()
        {
            return FindElement(nameOutputBy).Text;
        }

        public String GetOutputEmail()
        {
            return FindElement(emailOutputBy).Text;
        }

        public String GetOutputCurrentAddressBy()
        {
            return FindElement(currentOutputAddressBy).Text;
        }

        public String GetOutputPermanentAddress()
        {
            return FindElement(permantOutputAddressBy).Text;
        }
    }

    }

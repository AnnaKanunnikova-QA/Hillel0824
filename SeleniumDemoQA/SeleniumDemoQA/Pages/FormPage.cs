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
       
        By confirmationModalElement = By.Id("example-modal-sizes-title-lg");

        public FormPage(IWebDriver driver) : base(driver)
        {
            
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
    }
}

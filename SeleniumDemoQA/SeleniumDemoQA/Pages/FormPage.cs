using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class FormPage
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;
        By confirmationModalElement = By.Id("example-modal-sizes-title-lg");

        public FormPage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }

        public void ScrollTo(IWebElement element)
        {
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void FillInput(By selector, string value)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.SendKeys(value);
        }
        public void ClickElement(By selector)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.Click();
        }
        public void FillInputAndEnter(By selector, string value)
        {
            var webElement = _driver.FindElement(selector);
            ScrollTo(webElement);
            webElement.SendKeys(value);
            webElement.SendKeys(Keys.Enter);
        }
        public void ClickWithoutScroll(By selector)
        {
            var webElement = _driver.FindElement(selector);
            webElement.Click();
        }
        public void SelectText(By selector, string text)
        {
            var webElement = new SelectElement(_driver.FindElement(selector));
            webElement.SelectByText(text);
        }

        public string GetGss(string id)
        {
            var webElement = _driver.FindElement(By.Id(id));
            _js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            return webElement.GetCssValue("border-color");
        }

        public void FillInputById(string id, string fieldName)
        {
            FillInput(By.Id(id), fieldName);
        }


        public void ClickElementBySelector(string CssSelector)
        {
            ClickElement(By.CssSelector(CssSelector));
        }
        
        
        public void FillUserNumber(string userNumber)
        {
            FillInput(By.Id("userNumber"), userNumber);
        }


        public void ClickElementById(string id)
        {
           ClickElement(By.Id(id));
        }


        public void SelectTextByClassName(string className, string year)
        {
            SelectText(By.ClassName(className), year);
        }

        public void ClickElementByCssSelector(string selector)
        {
            ClickWithoutScroll(By.CssSelector(selector));
        }

        public void ClickElementByXPath(string selector)
        {
            ClickWithoutScroll(By.XPath(selector));
        }

        public void FillInpuctAndEnterByClassNameId(string elementId, string textName)
        {
            FillInputAndEnter(By.Id(elementId), textName);
        }

        //  string firstNameBorderColor = formPage.GetGss("firstName");


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

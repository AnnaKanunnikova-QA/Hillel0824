using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class BasePage
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _js = (IJavaScriptExecutor)_driver;
        }

        public void NavigateTo(string link)
        {
            _driver.Navigate().GoToUrl(link);
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
        public IWebElement FindElement(By by)
        {
            IWebElement element = _driver.FindElement(by);
            return element;
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Tests
{
    public class BaseClass
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200"); // Set desired resolution
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}

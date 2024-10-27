using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumDemoQA
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }


        public static void NavigateTo(this IWebDriver driver, string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void FillInput(this IWebDriver driver, By selector, string value)
        {
            var webElement = driver.FindElement(selector);
            ScrollTo(driver, webElement);
            webElement.SendKeys(value);
        }

        public static void ClickElement(this IWebDriver driver, By selector)
        {
            var webElement = driver.FindElement(selector);
            ScrollTo(driver, webElement);
            webElement.Click();
        }

        public static void FillInputAndEnter(this IWebDriver driver, By selector, string value)
        {
            var webElement = driver.FindElement(selector);
            ScrollTo(driver, webElement);
            webElement.SendKeys(value);
            webElement.SendKeys(Keys.Enter);
        }

        public static void ClickWithoutScroll(this IWebDriver driver, By selector)
        {
            var webElement = driver.FindElement(selector);
            webElement.Click();
        }

        public static void SelectByText(this IWebDriver driver, By selector, string text)
        {
            var webElement = new SelectElement(driver.FindElement(selector));
            webElement.SelectByText(text);
        }

        public static IWebElement FindElement(this IWebDriver driver, By by)
        {
            IWebElement element = driver.FindElement(by);
            return element;
        }
    }
}
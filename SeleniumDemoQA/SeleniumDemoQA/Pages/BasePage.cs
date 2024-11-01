using OpenQA.Selenium;

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
    }
}

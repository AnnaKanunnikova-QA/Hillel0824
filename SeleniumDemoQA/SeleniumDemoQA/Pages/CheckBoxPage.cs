using OpenQA.Selenium;

namespace SeleniumDemoQA.Pages
{
    internal class CheckBoxPage : BasePage
    {
        public CheckBoxPage(IWebDriver driver) : base(driver)
        {

        }

        private string pageUrl = "https://demoqa.com/checkbox";
        private By treeNodeHomeBy = By.XPath("//label[@for='tree-node-home']");
        private By resultBy = By.Id("result");
        private By TreeNodeHomeButtonBy = By.XPath("//label[@for='tree-node-home']/preceding-sibling::button");
        private By treeNodeDesktopBy = By.XPath("//label[@for='tree-node-desktop']");
        private By treeNodeDocumentsBy = By.XPath("//label[@for='tree-node-documents']");
        private By treeNodeDownloadsBy = By.XPath("//label[@for='tree-node-downloads']");

        public void ClickTreeHome()
        {
            _driver.ClickElement(treeNodeHomeBy);
        }

        public IWebElement GetResult()
        {
            return _driver.FindElement(resultBy);
        }

        public void ClickTreeHomeButton()
        {
            _driver.ClickElement(TreeNodeHomeButtonBy);
        }

        public IWebElement FindTreeDesktop()
        {
            return _driver.FindElement(treeNodeDesktopBy);
        }

        public IWebElement FindTreeDocument()
        {
            return _driver.FindElement(treeNodeDocumentsBy);
        }

        public IWebElement FindTreeDownloads()
        {
            return _driver.FindElement(treeNodeDownloadsBy);
        }

        public void OpenWebPage()
        {
            _driver.NavigateTo(pageUrl);
        }
    }
}
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Pages
{
    internal class CheckBoxPage : BasePage
    {
        public CheckBoxPage(IWebDriver driver) : base(driver)
        {

        }


        By treeNodeHomeBy = By.XPath("//label[@for='tree-node-home']");
        By resultBy = By.Id("result");
        By TreeNodeHomeButtonBy = By.XPath("//label[@for='tree-node-home']/preceding-sibling::button");
        By treeNodeDesktopBy = By.XPath("//label[@for='tree-node-desktop']");
        By treeNodeDocumentsBy = By.XPath("//label[@for='tree-node-documents']");
        By treeNodeDownloadsBy = By.XPath("//label[@for='tree-node-downloads']");

        public void ClickTreeHome()
        {
            ClickElement(treeNodeHomeBy);
        }

        public IWebElement GetResult()
        {
            return FindElement(resultBy);
        }

        public void ClickTreeHomeButton()
        {
            ClickElement(TreeNodeHomeButtonBy);
        }

        public IWebElement FindTreeDesktop()
        {
            return FindElement(treeNodeDesktopBy);
        }

        public IWebElement FindTreeDocument()
        {
            return FindElement(treeNodeDocumentsBy);
        }

        public IWebElement FindTreeDownloads()
        {
            return FindElement(treeNodeDownloadsBy);
        }






    }
}
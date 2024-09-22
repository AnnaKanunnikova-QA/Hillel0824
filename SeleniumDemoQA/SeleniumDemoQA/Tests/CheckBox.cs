using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeleniumDemoQA.Tests
{
    internal class CheckBox : BaseClass
    {

        [Test]
        public void CheckBoxTest()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            var formPage = new FormPage(_driver);
            formPage.ClickElement(By.XPath("//label[@for='tree-node-home']"));

            var resultCheckBox = _driver.FindElement(By.Id("result"));
            string expectedText = "You have selected :\r\nhome\r\ndesktop\r\nnotes\r\ncommands\r\ndocuments\r\nworkspace\r\nreact\r\nangular\r\nveu\r\noffice\r\npublic\r\nprivate\r\nclassified\r\ngeneral\r\ndownloads\r\nwordFile\r\nexcelFile";
            Assert.That(resultCheckBox.Text, Is.EqualTo(expectedText));
        }
        [Test]
public void ExpandHomeCheckBox()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/checkbox");

            // Expand the "Home" checkbox
            var formPage = new FormPage(_driver);
            formPage.ClickElement(By.XPath("//label[@for='tree-node-home']/preceding-sibling::button"));

            // Find and assert "Desktop" checkbox
            var resultdesktopCheckbox = _driver.FindElement(By.XPath("//label[@for='tree-node-desktop']"));
            var resultdesktopDocuments = _driver.FindElement(By.XPath("//label[@for='tree-node-documents']"));
            var resultdesktopDownloads = _driver.FindElement(By.XPath("//label[@for='tree-node-downloads']"));

            // Assert that the Desktop checkbox is displayed
            Assert.That(resultdesktopCheckbox.Displayed, Is.True);
            Assert.That(resultdesktopDocuments.Displayed, Is.True);
            Assert.That(resultdesktopDownloads.Displayed, Is.True);
    }
    }
}

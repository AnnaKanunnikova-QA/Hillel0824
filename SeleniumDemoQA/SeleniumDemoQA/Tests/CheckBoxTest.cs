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
    public class CheckBoxTest : BaseClass
    {

        [Test]

        public void BasicCheckBoxTest()
        {
            var checkBoxPage = new CheckBoxPage(_driver);
            checkBoxPage.NavigateTo("https://demoqa.com/checkbox");
            checkBoxPage.ClickTreeHome();
 
            string expectedText = "You have selected :\r\nhome\r\ndesktop\r\nnotes\r\ncommands\r\ndocuments\r\nworkspace\r\nreact\r\nangular\r\nveu\r\noffice\r\npublic\r\nprivate\r\nclassified\r\ngeneral\r\ndownloads\r\nwordFile\r\nexcelFile";
            Assert.That(checkBoxPage.GetResult().Text, Is.EqualTo(expectedText));
        }

        [Test]
        public void ExpandHomeCheckBox()

        {
            var checkBoxPage = new CheckBoxPage(_driver);
            checkBoxPage.NavigateTo("https://demoqa.com/checkbox");

            // Expand the "Home" checkbox
            checkBoxPage.ClickTreeHomeButton();

            // Find and assert "Desktop" checkbox
            var resultdesktopCheckbox = checkBoxPage.FindTreeDesktop();
            var resultdesktopDocuments = checkBoxPage.FindTreeDocument();
            var resultdesktopDownloads = checkBoxPage.FindTreeDownloads();

            // Assert that the Desktop checkbox is displayed
            Assert.Multiple(() =>
            {
                Assert.That(resultdesktopCheckbox.Displayed, Is.True);
                Assert.That(resultdesktopDocuments.Displayed, Is.True);
                Assert.That(resultdesktopDownloads.Displayed, Is.True);
            });
        }
    }
}

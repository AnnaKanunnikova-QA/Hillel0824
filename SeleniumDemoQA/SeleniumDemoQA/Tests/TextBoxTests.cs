﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;

namespace SeleniumDemoQA.Tests
{
    public class TextBoxTests: BaseClass
    {
        [Test]
        public void FillAndSubmitTest()
        {

            // Fill out the user name field
            FillInput(By.Id("userName"), "Anna Kanunnikova");
            // Fill out the emailfield
            FillInput(By.Id("userEmail"), "avkanunnikova@gmail.com");
            // Fill out the Current Address
            FillInput(By.Id("currentAddress"), "Funchal, Madeira");
            // Fill out the Permanent Address
            FillInput(By.Id("permanentAddress"),  "California, USA");
            // Click Submit button
            ClickElement(By.Id("submit"));

            var resultName = _driver.FindElement(By.Id("name"));
            Assert.That(resultName.Text, Is.EqualTo("Name:Anna Kanunnikova"));
            var resultEmail = _driver.FindElement(By.Id("email"));
            Assert.That(resultEmail.Text, Is.EqualTo("Email:avkanunnikova@gmail.com"));
            var resultCurrentAddress = _driver.FindElement(By.CssSelector("#output  #currentAddress"));
            Assert.That(resultCurrentAddress.Text, Is.EqualTo("Current Address :Funchal, Madeira"));
            var resultPermanentAddress = _driver.FindElement(By.CssSelector("#output  #permanentAddress"));
            Assert.That(resultPermanentAddress.Text, Is.EqualTo("Permananet Address :California, USA"));
        }

    }
}














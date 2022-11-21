﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation
{
    public class LoginTest
    {
        [Test]
        public void ValidLoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/");

            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys("admin123");
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();

            //wait for page load 

            //get the url and assert it
            string actualUrl = driver.Url;
            Assert.That(actualUrl, 
                Is.EqualTo("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index"));
        }

        [Test]
        public void InvalidLoginTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/");

            driver.FindElement(By.Name("username")).SendKeys("john");
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys("john123");
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();

            //assert the error message - Invalid credentials
            string actualError = driver.FindElement(By.XPath("//p[contains(@class,'oxd-alert')]")).Text;
            Assert.That(actualError, Is.EqualTo("Invalid credentials"));
        }
    }
}
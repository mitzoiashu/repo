using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace MyProteinAutomationSolution
{
    [TestClass]
    public class Testing
    {
        private IWebDriver driver;

        [TestMethod]
        public void Should_ceva()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.myprotein.ro");

            //TEST Alimente si gustari > Bauturi proteice
            Actions action = new Actions(driver);
            IWebElement btnCont = driver.FindElement(By.CssSelector("li[class='responsiveFlyoutMenu_levelOneItem-slide'] ~ [data-subnav-target='subnav-/myhealth-hub.list']"));
            action.MoveToElement(btnCont).Perform();
            Thread.Sleep(2000);



            Actions action2 = new Actions(driver);
            IWebElement btnCont2 = driver.FindElement(By.CssSelector("li[class='responsiveFlyoutMenu_levelTwoItem'] ~ [data-subnav-target='subnav-drinks']"));
            action2.MoveToElement(btnCont2).Perform();

            btnCont2.Click();


            //TEST VITAMINE > PIERDERI IN GREUTATE

            //Actions action = new Actions(driver);
            //IWebElement btnCont = driver.FindElement(By.CssSelector("[data-subnav-target='subnav-vitamins']"));
            //action.MoveToElement(btnCont).Perform();
            //Thread.Sleep(2000);



            //Actions action2 = new Actions(driver);
            //IWebElement btnCont2 = driver.FindElement(By.CssSelector("li[data-subnav-level='subnav-level-two'] ~ [data-subnav-target='subnav-weight-loss']"));
            //action2.MoveToElement(btnCont2).Perform();

            //btnCont2.Click();

            //driver.Quit();

        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProteinAutomationSolution.PageObjects;
using MyProteinAutomationSolution.PageObjects.InputData;
using MyProteinAutomationSolution.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProteinAutomationSolution
{
    [TestClass]
    public class AddressTests
    {
        private IWebDriver driver;
        private NewAddressPage newAddressPage;
        private LoginPage loginPage;

        [TestInitialize]
        public void AddressSetup()
        {
            //open browser
            driver = new ChromeDriver();
            //init login page 
            loginPage = new LoginPage(driver);
            //maximize window
            driver.Manage().Window.Maximize();
            //access the URL of the system
            driver.Navigate().GoToUrl("https://www.myprotein.ro");
            //init HomePage class
            var homePage = new HomePage(driver);
            WaitHelpers.WaitElementIsVisible(driver, homePage.Cookies);
            WaitHelpers.WaitElementToBeClickable(driver, homePage.Cookies);
            //accept cookies
            homePage.BtnCookie.Click();
            //click sign in button
            homePage.btnCont.Click();


        }
        [TestCleanup]
        public void AddressCleanUp()
        {
            driver.Quit();
        }
        [TestMethod]
        public void Should_successfully_add_new_addresses()
        {
            var newLoginBO = new NewLoginBO();
            var newAddressBO = new NewAddressBO();
            var homePage = loginPage.LoginApplication(newLoginBO);

            var addressPage = homePage.NavigateToAddressPage();
            newAddressPage = addressPage.NavigateToNewAddressPage();
            newAddressPage.AdaugaAdresaLivrare(newAddressBO);

            Assert.AreEqual(newAddressBO.NumePrenume, addressPage.matchString(newAddressBO));
        }

        [TestMethod]
        public void Should_successfully_delete_addresses()
        {
            var newLoginBO = new NewLoginBO();
            var newAddressBO = new NewAddressBO();
            var homePage = loginPage.LoginApplication(newLoginBO);

            var addressPage = homePage.NavigateToAddressPage();
            //newAddressPage = addressPage.NavigateToNewAddressPage();
            addressPage.StergeAdresaLivrare(newAddressBO);

            Assert.AreNotEqual(newAddressBO.NumePrenume, addressPage.matchString(newAddressBO));

        }
        [TestMethod]
        public void Should_successfully_modify_addresses()
        {
            var newLoginBO = new NewLoginBO();
            var newAddressBO = new NewAddressBO()
            {
                NumePrenume = "Testing Delivery",
                CodPostal = "68938",
                NrCasei = "19",
                AdresaLivrare1="str. Italienilor",
                Oras = "Venetia"
            };
            var homePage = loginPage.LoginApplication(newLoginBO);

            var addressPage = homePage.NavigateToAddressPage();
            addressPage.ModificaAdresaLivrare(newAddressBO);
            Assert.AreEqual(addressPage.checkAdresaLivrare(newAddressBO), MethodHelpers.stringAdresaLivrare(newAddressBO));
        }

    }
}

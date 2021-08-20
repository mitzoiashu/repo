using System;
using System.Collections.Generic;
using MyProteinAutomationSolution.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyProteinAutomationSolution.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By LoginUser = By.XPath("//p[@class='myAccountSection_header_welcome']");
        public IWebElement LblLogin => driver.FindElement(LoginUser);

        private By RegisterUser = By.XPath("//div[@class='responsiveAccountHeader_accountName']");
        public IWebElement LblRegister => driver.FindElement(RegisterUser);

        public By Cookies = By.ClassName("cookie_modal_button");
        public IWebElement BtnCookie => driver.FindElement(Cookies);

        private By LoginFailed = By.XPath("//div[@data-alert='error']");
        public IWebElement LblLoginFailed => driver.FindElement(LoginFailed);

        private By Cont = By.CssSelector("span[class=responsiveAccountHeader_openAccountPanelText");
        public IWebElement btnCont => driver.FindElement(Cont);

        private By RegisterPanel = By.XPath("//a[@data-context='register']");
        public IWebElement BtnRegister => driver.FindElement(RegisterPanel);

        private By SettingsUser = By.ClassName("responsiveSettingsCard_title");
        public IList<IWebElement> LstSettingsUser => driver.FindElements(SettingsUser);

        public AddressPage NavigateToAddressPage()
        {
            WaitHelpers.WaitElementIsVisible(driver, SettingsUser);
            LstSettingsUser[3].Click();
            return new AddressPage(driver);
        }

        public ProductPage NavigateToProductPage()
        {
            return new ProductPage(driver);
        }

    }
}

using System;
using System.Collections.Generic;
using MyProteinAutomationSolution.PageObjects;
using MyProteinAutomationSolution.PageObjects.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyProteinAutomationSolution
{
    public class RegisterPage
    {
        public IWebDriver driver;

        public RegisterPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement TxtNumePrenume => driver.FindElement(By.Name("customerName"));
        public IWebElement TxtEmail => driver.FindElement(By.Name("customerEmail"));
        public IWebElement TxtConfirmEmail => driver.FindElement(By.Name("confirmCustomerEmail"));
        public IWebElement TxtPassword => driver.FindElement(By.Name("customerPassword"));
        public IWebElement TxtConfirmPassword => driver.FindElement(By.Name("confirmPassword"));

        public IList<IWebElement> LstOptions => driver.FindElements(By.CssSelector("input[name=OptInReceiveNewsLetterRadio]"));

        public IWebElement SwitchPass => driver.FindElement(By.XPath("//div[@class='toggleSwitch_canvas']"));

        public IWebElement BtnContinue => driver.FindElement(By.CssSelector("button[id='continue']"));

        public HomePage RegisterApplication(NewRegisterBO newRegisterBO)
        {
            TxtNumePrenume.SendKeys(newRegisterBO.NumePrenume);
            TxtEmail.SendKeys(newRegisterBO.Email);
            TxtConfirmEmail.SendKeys(newRegisterBO.Email);
            TxtPassword.SendKeys(newRegisterBO.Password);
            TxtConfirmPassword.SendKeys(newRegisterBO.Password);

            SwitchPass.Click();
            //SwitchPass.Click();

            LstOptions[newRegisterBO.MktOptions].Click();

            BtnContinue.Click();

            hoverMouse();

            return new HomePage(driver);
        }

        public void hoverMouse()
        {
            Actions action = new Actions(driver);
            IWebElement btnCont = driver.FindElement(By.CssSelector("span[class=responsiveAccountHeader_openAccountPanelText"));
            action.MoveToElement(btnCont).Perform();
        }
    }
}

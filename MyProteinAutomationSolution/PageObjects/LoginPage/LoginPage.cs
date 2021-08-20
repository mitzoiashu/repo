using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProteinAutomationSolution.PageObjects;
using MyProteinAutomationSolution.PageObjects.InputData;
using OpenQA.Selenium;

namespace MyProteinAutomationSolution
{
    public class LoginPage
    {
        public IWebDriver driver;
        //public NewLoginBO newLoginBO;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement TxtEmail => driver.FindElement(By.CssSelector("input[type=email]"));
        public IWebElement TxtPassword => driver.FindElement(By.CssSelector("input[type=password"));
        public IWebElement BtnSignIn => driver.FindElement(By.XPath("//button[@type='submit']"));

        public HomePage LoginApplication(NewLoginBO newLoginBO)
        {
            TxtEmail.SendKeys(newLoginBO.EmailLogin);
            TxtPassword.SendKeys(newLoginBO.PasswordLogin);

            //scroll window down
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollBy(0,250)", "");

            BtnSignIn.Click();
            return new HomePage(driver);
        }
        public AccountPage NavigateToAccountPage()
        {
            return new AccountPage(driver);
        }

    }
}

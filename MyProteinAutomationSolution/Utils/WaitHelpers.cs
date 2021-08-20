using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MyProteinAutomationSolution.Utils
{
    public static class WaitHelpers
    {
        public static void WaitElementIsVisible(IWebDriver driver, By by, int timeSpan = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public static void WaitElementToBeClickable(IWebDriver driver, By by, int timeSpan = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        public static void WaitTextToBePresentInElementLocated(IWebDriver driver, By by, string text, int timeSpan = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }
    }
}

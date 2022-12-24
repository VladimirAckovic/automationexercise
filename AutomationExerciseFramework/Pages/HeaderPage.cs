using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class HeaderPage
    {
        readonly IWebDriver _driver;
        public By header = By.Id("header");
        public By loginLink = By.ClassName("fa-lock");
        public By deleteAcc = By.ClassName("fa-trash-o");
        public HeaderPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(header));
        }
    }
}

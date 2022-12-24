using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFramework.Pages
{
    class AccountCreatedPage
    {
        readonly IWebDriver _driver;
        public By page = By.CssSelector(".row [data-qa='account-created']");
        public By continueBtn = By.CssSelector(".pull-right [data-qa='continue-button']");

        public AccountCreatedPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(page));
        }
    }
}

using AutomationExerciseFramework.Helpers;
using AutomationExerciseFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFramework.Steps
{
    [Binding]
    public class AuthenticationSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPages()
        {
            ut.ClickOnElement(hp.loginLink);
        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.loginEmail, TestConstans.Username);
            ut.EnterTextInElement(ap.loginPassword, TestConstans.Password);
        }
        
        [When(@"user submit login form")]
        public void WhenUserSubmitLoginForm()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.loginBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Assert.True(ut.ElementIsDisplayed(hp.deleteAcc), "User is NOT logged in");
        }

         

        [Given(@"enters '(.*)' name and valid email address")]
        public void GivenEntersNameAndValidEmailAddress(string name)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.name, name);
            ut.EnterTextInElement(ap.singupEmail, ut.GenerateRandomEmail());
        }

        [Given(@"user clicks on SignUp button")]
        public void GivenUserClicksOnSignUpButton()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.singupBtn);
        }

        [When(@"user fills in all required fields")]
        public void WhenUserFillsInAllRequiredFields()
        {
            SignupPages sp = new SignupPages(Driver);
            ut.EnterTextInElement(sp.password, TestConstans.Password);
            ut.EnterTextInElement(sp.firstName, TestConstans.FirstName);
            ut.EnterTextInElement(sp.lastName, TestConstans.LastName);
            ut.EnterTextInElement(sp.address, TestConstans.Address);
            ut.DropdownSelect(sp.country, TestConstans.Country);
            ut.EnterTextInElement(sp.state, TestConstans.State);
            ut.EnterTextInElement(sp.city, TestConstans.City);
            ut.EnterTextInElement(sp.zipcode, TestConstans.ZipCode);
            ut.EnterTextInElement(sp.mobile, TestConstans.Phone);
        }

        [When(@"submits the signup form")]
        public void WhenSubmitsTheSignupForm()
        {
            SignupPages sp = new SignupPages(Driver);
            Driver.FindElement(sp.form).Submit();
            //ut.ClickOnElement(sp.createAcc);
        }

        [Then(@"user will get '(.*)' success message")]
        public void ThenUserWillGetSuccessMessage(string message)
        {
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            Assert.True(ut.TextPresentInElement(message), "User did NOT get expected success message");
            ut.ClickOnElement(acp.continueBtn);
        }

    }
}

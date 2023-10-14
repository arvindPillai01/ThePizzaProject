using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace PizzaSpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7074/Identity/Account/Login");
            Thread.Sleep(1000);
		}



        [When(@"the user enters valid username and password")]
        public void WhenTheUserEntersValidUsernameAndPassword()
        {
            driver.FindElement(By.XPath("//*[@id=\"Input_Email\"]")).SendKeys("aps@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"Input_Password\"]")).SendKeys("Abcd@1234");
            Thread.Sleep(1000);
		}

        [When(@"clicks the login button")]
        public void WhenClicksTheLoginButton()
        {
            driver.FindElement(By.Id("login-submit")).Click();
        }



        [Then(@"they should be logged in successfully")]
        public void ThenTheyShouldBeLoggedInSuccessfully()
        {
            string expectedUrl = "https://localhost:7074/";
            string currentUrl = driver.Url;

            Assert.AreEqual(expectedUrl, currentUrl, "Expected to be redirected to the correct URL after login.");
        }
    }
}
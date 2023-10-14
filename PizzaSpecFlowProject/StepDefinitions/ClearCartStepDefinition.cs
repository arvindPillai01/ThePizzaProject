using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace PizzaSpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class ClearCartStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"the user is on the cart page")]
        public void GivenTheUserIsOnTheCartPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7074/Identity/Account/Login");
            driver.FindElement(By.XPath("//*[@id=\"Input_Email\"]")).SendKeys("aps@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"Input_Password\"]")).SendKeys("Abcd@1234");
            driver.FindElement(By.Id("login-submit")).Click();
            Thread.Sleep(1000);
			string expectedUrl = "https://localhost:7074/";
            string currentUrl = driver.Url;
            Assert.AreEqual(expectedUrl, currentUrl, "Expected to be redirected to the correct URL after login.");
            driver.Navigate().GoToUrl("https://localhost:7074/Checkout/Checkout");
            Thread.Sleep(1000);
		}

        [When(@"the user clicks the clear cart button")]
        public void WhenTheUserClicksTheClearCartButton()
        {
            // Click the button to clear the cart
            driver.FindElement(By.XPath("/html/body/div/main/div[2]/button[1]")).Click();
            Thread.Sleep(1000);
			// Switch to the alert
			IAlert alert = driver.SwitchTo().Alert();
			Thread.Sleep(1000);
			// Accept the alert (click "OK" or "Yes")
			alert.Accept();
			Thread.Sleep(1000);
		}

        [Then(@"the cart should be empty")]
        public void ThenTheCartShouldBeEmpty()
        {
            // Check if the cart is empty (implement based on your application behavior)
            var cartEmptyMessage = driver.FindElement(By.XPath("//td[@id='totalPrice'][contains(text(), '$0')]"));

			Assert.IsNotNull(cartEmptyMessage, "Cart is not empty.");
        }
         
    }
}

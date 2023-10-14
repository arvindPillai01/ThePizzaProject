using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace PizzaSpecFlowProject.StepDefinitions
{
	[Binding]
	public sealed class ConfirmationStepDefinitions
	{
		private IWebDriver driver;

		[Given(@"the user is on the cart page to reach confirmation page")]
		public void GivenTheUserIsOnTheCartPageToReachConfirmationPage()
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

		[When(@"the user clicks the confirm button")]
		public void WhenTheUserClicksTheConfirmButton()
		{
			driver.FindElement(By.XPath("/html/body/div/main/div[2]/button[2]")).Click();
			Thread.Sleep(1000);
			// Clicking home button on the confirmation page
			driver.FindElement(By.XPath("/html/body/div/main/div[3]/a/button")).Click();
			Thread.Sleep(1000);
		}

		[Then(@"reaches the confirmation page")]
		public void ThenReachesTheConfirmationPage()
		{
			string expectedUrl = "https://localhost:7074/";
			string currentUrl = driver.Url;

			Assert.AreEqual(expectedUrl, currentUrl, "Expected to be redirected to the cHome page after Confirmation page Home button clicked.");
		}


	}
}

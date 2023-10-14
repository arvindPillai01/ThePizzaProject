using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PizzaSpecFlowProject.StepDefinitions
{
    [Binding]

    public sealed class AddPizzaStepDefinitions
    {

        private static IWebDriver driver;

        [Given(@"the user is on the pizza ordering page")]
        public void GivenTheUserIsOnThePizzaOrderingPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7074/Identity/Account/Login");
            driver.FindElement(By.XPath("//*[@id=\"Input_Email\"]")).SendKeys("aps@gmail.com");
            driver.FindElement(By.XPath("//*[@id=\"Input_Password\"]")).SendKeys("Abcd@1234");
            driver.FindElement(By.Id("login-submit")).Click();
            string expectedUrl = "https://localhost:7074/";
            string currentUrl = driver.Url;
            Assert.AreEqual(expectedUrl, currentUrl, "Expected to be redirected to the correct URL after login.");
            Thread.Sleep(1000);
            //if (driver == null)
            //{
            //    driver = new ChromeDriver();
            //    driver.Manage().Window.Maximize();
            //    driver.Url = "https://localhost:7074/";
            //    Thread.Sleep(1000);
            //}
        }

        [When(@"the user selects a pizza and adds it to the cart")]
        public void WhenTheUserSelectsAPizzaAndAddsItToTheCart()
        {

            driver.FindElement(By.XPath("//*[@id=\"quantity-1\"]")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"quantity-1\"]")).SendKeys("6");
            Thread.Sleep(1000);


            string xpath = $"//button[@id=\"1\"]";
            var addToCartButton = driver.FindElement(By.XPath(xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", addToCartButton);

            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://localhost:7074/Checkout/Checkout");

        }

        [Then(@"the pizza should be added to the cart")]
        public void ThenThePizzaShouldBeAddedToTheCart()
        {
            // Implement verification that the pizza was added to the cart
            var pizzaName = driver.FindElement(By.XPath("//td[@id='pizzaName'][contains(text(), 'Blazing Onion & Paprika')]"));
            Assert.IsNotNull(pizzaName, "Pizza not found in the cart.");
        }


    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

//namespace PizzaSpecFlowProject.StepDefinitions
//{
//    [Binding]
//    [Order(1)]
//    [Category("Login")]
//    public class LoginStepDefinitions
//    {
//        private IWebDriver driver;

//        [Given(@"the user is on the login page")]
//        public void GivenTheUserIsOnTheLoginPage()
//        {
//            driver = new ChromeDriver();
//            driver.Navigate().GoToUrl("https://localhost:7074/Identity/Account/Login");
//        }

//        [When(@"the user enters valid username and password")]
//        public void WhenTheUserEntersValidUsernameAndPassword()
//        {
//            driver.FindElement(By.XPath("//*[@id=\"Input_Email\"]")).SendKeys("aps@gmail.com");
//            driver.FindElement(By.XPath("//*[@id=\"Input_Password\"]")).SendKeys("Abcd@1234");
//        }

//        [When(@"clicks the login button")]
//        public void WhenClicksTheLoginButton()
//        {
//            driver.FindElement(By.Id("login-submit")).Click();
//        }

//        [Then(@"they should be logged in successfully")]
//        public void ThenTheyShouldBeLoggedInSuccessfully()
//        {
//            string expectedUrl = "https://localhost:7074/";
//            string currentUrl = driver.Url;

//            Assert.AreEqual(expectedUrl, currentUrl, "Expected to be redirected to the correct URL after login.");
//        }
//    }


//    [Order(2)]
//    [Category("AddingItem")]
//    public sealed class AddPizzaStepDefinitions
//    {

//        private static IWebDriver driver;

//        [Given(@"the user is on the pizza ordering page")]
//        public void GivenTheUserIsOnThePizzaOrderingPage()
//        {
//            if (driver == null)
//            {
//                driver = new ChromeDriver();
//                driver.Manage().Window.Maximize();
//                driver.Url = "https://localhost:7074/";
//                Thread.Sleep(1000);
//            }
//        }

//        [When(@"the user selects a pizza and adds it to the cart")]
//        public void WhenTheUserSelectsAPizzaAndAddsItToTheCart()
//        {

//            driver.FindElement(By.XPath("//*[@id=\"quantity-1\"]")).Clear();
//            driver.FindElement(By.XPath("//*[@id=\"quantity-1\"]")).SendKeys("6");

//            string xpath = $"//button[@id=\"1\"]";
//            var addToCartButton = driver.FindElement(By.XPath(xpath));
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            js.ExecuteScript("arguments[0].click();", addToCartButton);
//            Thread.Sleep(1000);




//            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            //var addToCartButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
//            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            //js.ExecuteScript("arguments[0].scrollIntoView();", addToCartButton);
//            //Console.WriteLine("Before clicking");
//            //js.ExecuteScript("arguments[0].click();", addToCartButton);
//            //Console.WriteLine("After clicking");



 

//            Thread.Sleep(3000);





//            //var addToCartButton = driver.FindElement(By.XPath("//button[@id=\"addButton-1\"]"));

//            //         // Use JavaScriptExecutor to click the button
//            //         IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            //         js.ExecuteScript("arguments[0].click();", addToCartButton);


//            //IWebElement element = driver.FindElement(By.XPath("//*[@id=\"addButton-1\"]"));
//            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
//            //Thread.Sleep(1000);  // Add a small delay for the scroll to take effect
//            //element.Click();

//            //driver.FindElement(By.XPath("//*[@id=\"addButton-2\"]")).Click();

//            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            //var quantityInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("quantity-1")));

//            //// Clear the quantity input field and enter the quantity
//            //quantityInput.Clear();
//            //quantityInput.SendKeys("6");

//            //// Wait for the "Add to Cart" button to be visible and enabled
//            //var addToCartButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[data-pizza-id='1']")));

//            //// Click the "Add to Cart" button
//            //addToCartButton.Click();

//        }

//        [Then(@"the pizza should be added to the cart")]
//        public void ThenThePizzaShouldBeAddedToTheCart()
//        {
//            // Implement verification that the pizza was added to the cart
//            // This will involve interacting with your application and asserting the expected behavior
//        }

//        [When(@"the user selects multiple pizzas and adds them to the cart")]
//        public void WhenTheUserSelectsMultiplePizzasAndAddsThemToTheCart()
//        {
//            // Implement selecting multiple pizzas and adding them to the cart
//            // This will involve interacting with your application
//        }

//        [Then(@"all selected pizzas should be added to the cart")]
//        public void ThenAllSelectedPizzasShouldBeAddedToTheCart()
//        {
//            // Implement verification that all selected pizzas were added to the cart
//            // This will involve interacting with your application and asserting the expected behavior
//        }
//    }
//}

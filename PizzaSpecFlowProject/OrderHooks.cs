//using System.Threading;
//using TechTalk.SpecFlow;

//namespace PizzaSpecFlowProject
//{
//    [Binding]
//    public sealed class OrderHooks
//    {

//        [BeforeScenario("addingItem")]
//        public void BeforeAddingItemScenario()
//        {
//            // Run the login steps first
//            GivenTheUserIsOnTheLoginPage();
//            WhenTheUserEntersValidUsernameAndPassword();
//            WhenClicksTheLoginButton();
//            ThenTheyShouldBeLoggedInSuccessfully();

//            // Delay to allow for the login process to complete (you may need to adjust this)
//            Thread.Sleep(2000);

//            // Proceed to the steps for adding a pizza
//            GivenTheUserIsOnThePizzaOrderingPage();
//            WhenTheUserSelectsAPizzaAndAddsItToTheCart();
//            ThenThePizzaShouldBeAddedToTheCart();
//        }
//    }
//}

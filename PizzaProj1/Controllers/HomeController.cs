using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using PizzaProj1.Data;
using PizzaProj1.Models;
using System.Diagnostics;

namespace PizzaProj1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _dbContext;
		private readonly UserManager<IdentityUser> _userManager; // Corrected the user model type

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
		{
			_logger = logger;
			_dbContext = dbContext;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var pizzaItems = _dbContext.Pizzas.ToList();
			return View(pizzaItems);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int pizzaId, int quantity) // Added async and Task for correct usage of await
		{
			IdentityUser user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return BadRequest("User is not authenticated.");
			}

			string userId = user.Id;

			var cartItem = new CartItem
			{
				PizzaId = pizzaId,
				Quantity = quantity,
				UserId = userId
			};

			_dbContext.Carts.Add(cartItem);
			_dbContext.SaveChanges();

			    //HttpContext.Session.SetString("UserId", userId);

			return Json(new { success = true, message = "Product added to cart successfully!" });
		}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaProj1.Data;

namespace PizzaProj1.Controllers
{
	public class CheckoutController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly UserManager<IdentityUser> _userManager; // Corrected the user model type


		public CheckoutController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
		}

		public async Task<IActionResult> Checkout()
		{
			IdentityUser user = await _userManager.GetUserAsync(User);
			//string userId = HttpContext.Session.GetString("UserId");
			string userId = user.Id;
			if (userId != null)
			{
				var cartItems = _dbContext.Carts
					.Include(cartItem => cartItem.Pizza)
					.Where(cartItem => cartItem.UserId == userId)
					.ToList();

				return View(cartItems);
			}

			// If user is not authenticated, you may want to handle this accordingly
			return RedirectToAction("Index", "Home");

		}

		[HttpPost]
		public async Task<IActionResult> ClearCart()
		{
			IdentityUser user = await _userManager.GetUserAsync(User);
			string userId = user.Id;

			var cartItems = _dbContext.Carts
				.Where(cartItem => cartItem.UserId == userId);

			_dbContext.Carts.RemoveRange(cartItems);
			await _dbContext.SaveChangesAsync();

			return Content("");
			;
		}

		[HttpPost]
		public async Task<IActionResult> RemoveCartItem(int cartId)
		{
			var cartItem = await _dbContext.Carts.FindAsync(cartId);

			if (cartItem == null)
			{
				return NotFound(); // Return a 404 Not Found if the cart item is not found
			}

			_dbContext.Carts.Remove(cartItem);
			await _dbContext.SaveChangesAsync();

			return Ok();
		}
	}
}

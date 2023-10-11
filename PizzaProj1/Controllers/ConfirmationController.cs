using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaProj1.Controllers;
using PizzaProj1.Data;

namespace PizzaProj1.Controllers
{
    public class ConfirmationController : Controller
    {

	    private readonly ApplicationDbContext _dbContext;
	    private readonly UserManager<IdentityUser> _userManager; // Corrected the user model type


	    public ConfirmationController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
	    {
		    _dbContext = dbContext;
		    _userManager = userManager;
	    }

	    public async Task<IActionResult> ConfirmationPage()
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
    }
}

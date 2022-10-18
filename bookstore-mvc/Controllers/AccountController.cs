using bookstore_mvc.Data;
using bookstore_mvc.Data.ViewModels;
using bookstore_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _context = context;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
      return View(new LoginVM());
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
      return View(new LoginVM());
    }


    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
  }
}
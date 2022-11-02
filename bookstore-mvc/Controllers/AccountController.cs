using System.Security.Claims;
using bookstore_mvc.Data;
using bookstore_mvc.Data.Services;
using bookstore_mvc.Data.Static;
using bookstore_mvc.Data.ViewModels;
using bookstore_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
   private readonly IAccountService _service;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(IAccountService service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _service = service;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var userId = _userManager.GetUserId(HttpContext.User);
      if (userId == null)
      {
        return RedirectToAction("Login", "Account");
      }

      ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

      return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ApplicationUser userInfo)
    {
      await _service.UpdateUserAsync(userInfo);
      return RedirectToAction(nameof(Index));
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
      return View(new LoginVM());
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
      return View(new RegisterVM());
    }


    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {

      if (!ModelState.IsValid) return View(loginVM);

      var user = await _userManager.FindByEmailAsync(loginVM.Email);
      if (user != null)
      {
        var userExists = await _userManager.CheckPasswordAsync(user, loginVM.Password);
        if (userExists)
        {
          var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
          if (result.Succeeded)
          {
            return RedirectToAction("Index", "Books");
          }
        }
        TempData["Error"] = "Wrong credentials. Please, try again!";
        return View(loginVM);
      }

      TempData["Error"] = "Are you here for the first time? Please, register first!";
      return View(loginVM);
    }


    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
      if (!ModelState.IsValid) return View(registerVM);

      var user = await _userManager.FindByEmailAsync(registerVM.Email);
      if (user != null)
      {
        TempData["Error"] = "This email address is already taken!";
        return View(registerVM);
      }

      var newUser = new ApplicationUser()
      {
        FullName = registerVM.FullName,
        Email = registerVM.Email,
        UserName = registerVM.Email
      };
      var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

      if (newUserResponse.Succeeded)
      {
        await _userManager.AddToRoleAsync(newUser, UserRoles.User);
      }

      return View("RegistrationSuccess");
    }

    [HttpPost]
    [Route("Logout")]
    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Books");
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
  }
}
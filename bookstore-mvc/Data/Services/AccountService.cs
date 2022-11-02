using bookstore_mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace bookstore_mvc.Data.Services
{
  public class AccountService : IAccountService
  {
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;


    public AccountService(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    public async Task UpdateUserAsync(ApplicationUser user)
    {
      var userInfo = await _userManager.FindByIdAsync(user.Id);

      if (userInfo != null)
      {
        userInfo.FullName = user.FullName;
        userInfo.UserName = user.UserName;
        userInfo.Email = user.Email;
        userInfo.PhoneNumber = user.PhoneNumber;

        await _context.SaveChangesAsync();
      };
    }
  }
}
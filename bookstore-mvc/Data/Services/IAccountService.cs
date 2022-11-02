using bookstore_mvc.Models;

namespace bookstore_mvc.Data.Services
{
  public interface IAccountService
  {
    Task UpdateUserAsync(ApplicationUser user);
  }
}
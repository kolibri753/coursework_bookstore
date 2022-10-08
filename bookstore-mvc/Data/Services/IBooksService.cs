using bookstore_mvc.Models;
using bookstore_mvc.Data.Base;
using bookstore_mvc.Data.ViewModels;

namespace bookstore_mvc.Data.Services
{
  public interface IBooksService : IEntityBaseRepository<Book>
    {
      Task<Book> GetBookByIdAsync(int id);
      Task<BookDroupdownMenuVM> GetBookDroupownMenuValues();
      Task AddNewBookAsync (NewBookVM item);
      Task UpdateBookAsync (NewBookVM item);
    }
}
using bookstore_mvc.Models;
using bookstore_mvc.Data.Base;

namespace bookstore_mvc.Data.Services
{
  public interface IBooksService : IEntityBaseRepository<Book>
    {

    }
}
using bookstore_mvc.Data.Base;
using bookstore_mvc.Models;

namespace bookstore_mvc.Data.Services
{
  public interface IAuthorsService : IEntityBaseRepository<Author>
    {
        Task<Author> GetAuthorByIdAsync(int id);
    }
}
using bookstore_mvc.Models;

namespace bookstore_mvc.Data.Services
{
  public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync (int id);
        Task AddAsync (Book book);
        Task<Book> UpdateAsync (int id, Book newBook);
        Task DeleteAsync (int id);

    }
}
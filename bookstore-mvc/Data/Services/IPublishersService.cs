using bookstore_mvc.Data.Base;
using bookstore_mvc.Models;

namespace bookstore_mvc.Data.Services
{
  public interface IPublishersService : IEntityBaseRepository<Publisher>
  {
    Task<Publisher> GetPublisherByIdAsync(int id);
  }
}
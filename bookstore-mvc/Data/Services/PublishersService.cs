using bookstore_mvc.Data.Base;
using bookstore_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_mvc.Data.Services
{
  public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
  {
    private readonly AppDbContext _context;

    public PublishersService(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Publisher> GetPublisherByIdAsync(int id)
    {
      var publisherInfo = await _context.Publishers
            .Include(b => b.Books)
            .FirstOrDefaultAsync(n => n.Id == id);

      return publisherInfo;
    }
  }
}
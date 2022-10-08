using bookstore_mvc.Models;
using bookstore_mvc.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace bookstore_mvc.Data.Services
{
  public class BooksService : EntityBaseRepository<Book>, IBooksService
  {
    private readonly AppDbContext _context;

    public BooksService(AppDbContext context) : base(context) { }
  }
}
using bookstore_mvc.Models;
using bookstore_mvc.Data.Base;
using Microsoft.EntityFrameworkCore;
using bookstore_mvc.Data.ViewModels;

namespace bookstore_mvc.Data.Services
{
  public class BooksService : EntityBaseRepository<Book>, IBooksService
  {
    private readonly AppDbContext _context;

    public BooksService(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task AddNewBookAsync(NewBookVM item)
    {
      var newBook = new Book()
      {
        ImageURL = item.ImageURL,
        Title = item.Title,
        Pages = item.Pages,
        Price = item.Price,
        Quantity = item.Quantity,
        Genre = item.Genre,
        AuthorId = item.AuthorId,
        PublisherId = item.PublisherId
      };
      await _context.Books.AddAsync(newBook);
      await _context.SaveChangesAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
      var bookInfo = await _context.Books
        .Include(a => a.Author)
        .Include(p => p.Publisher)
        .FirstOrDefaultAsync(n => n.Id == id);

      return bookInfo;
    }

    public async Task<BookDroupdownMenuVM> GetBookDroupownMenuValues()
    {
      var response = new BookDroupdownMenuVM()
      {
        Authors = await _context.Authors.OrderBy(n => n.Name).ToListAsync(),
        Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync(),
      };

      return response;
    }

    public async Task UpdateBookAsync(NewBookVM item)
    {
      var bookInfo = await _context.Books.FirstOrDefaultAsync(n => n.Id == item.Id);

      if (bookInfo != null)
      {
        bookInfo.ImageURL = item.ImageURL;
        bookInfo.Title = item.Title;
        bookInfo.Pages = item.Pages;
        bookInfo.Price = item.Price;
        bookInfo.Quantity = item.Quantity;
        bookInfo.Genre = item.Genre;
        bookInfo.AuthorId = item.AuthorId;
        bookInfo.PublisherId = item.PublisherId;
        await _context.SaveChangesAsync();
      };
    }
  }
}
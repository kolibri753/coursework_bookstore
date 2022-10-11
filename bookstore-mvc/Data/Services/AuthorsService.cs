using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Data.Base;
using bookstore_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_mvc.Data.Services
{
  public class AuthorsService : EntityBaseRepository<Author>, IAuthorsService
  {
    private readonly AppDbContext _context;

    public AuthorsService(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        var authorInfo = await _context.Authors
            .Include(b => b.Books)
            .FirstOrDefaultAsync(n => n.Id == id);

        return authorInfo;
    }

  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_mvc.Data.Cart
{
  public class ShoppingCart
  {
    public AppDbContext _context { get; set; }

    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public ShoppingCart(AppDbContext context)
    {
      _context = context;
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
      ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
      var context = services.GetService<AppDbContext>();

      string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
      session.SetString("CartId", cartId);

      return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
      return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId).Include(i => i.Book).ToList());
    }

    public double GetShoppingCartTotal()
    {
      return _context.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId).Select(i => i.Book.Price * i.Quantity).Sum();
    }

    public void AddItemToCart(Book book)
    {
      var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(i => i.Book.Id == book.Id && i.ShoppingCartId == ShoppingCartId);

      if (shoppingCartItem == null)
      {
        shoppingCartItem = new ShoppingCartItem()
        {
          ShoppingCartId = ShoppingCartId,
          Book = book,
          Quantity = 1
        };

        _context.ShoppingCartItems.Add(shoppingCartItem);
      }
      else //if already added
      {
        shoppingCartItem.Quantity++;
      }
      _context.SaveChanges();
    }

    public void RemoveItemFromCart(Book book)
    {
      var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(i => i.Book.Id == book.Id && i.ShoppingCartId == ShoppingCartId);

      if (shoppingCartItem != null)
      {
        if (shoppingCartItem.Quantity > 1)
        {
          shoppingCartItem.Quantity--;
        }
        else
        {
          _context.ShoppingCartItems.Remove(shoppingCartItem);
        }
      }
      _context.SaveChanges();
    }

    public async Task ClearShoppingCartAsync()
    {
      var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
      _context.ShoppingCartItems.RemoveRange(items);
      await _context.SaveChangesAsync();
    }

  }
}
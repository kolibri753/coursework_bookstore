using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_mvc.Data.Services
{
  public class OrdersService : IOrdersService
  {
    private readonly AppDbContext _context;
    public OrdersService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
    {
      var orders = await _context.Orders.Include(n => n.Books_Orders).ThenInclude(n => n.Book).Include(n => n.User).ToListAsync();

      if (userRole != "Admin")
      {
        orders = orders.Where(n => n.UserId == userId).ToList();
      }

      return orders;
    }

    public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
    {
      var order = new Order()
      {
        UserId = userId,
        Email = userEmailAddress
      };
      await _context.Orders.AddAsync(order);
      await _context.SaveChangesAsync();

      foreach (var item in items)
      {
        var bookOrder = new Book_Order()
        {
          Quantity = item.Quantity,
          BookId = item.Book.Id,
          OrderId = order.Id,
          Price = item.Book.Price
        };
        await _context.Books_Orders.AddAsync(bookOrder);
      }
      await _context.SaveChangesAsync();
    }
  }
}
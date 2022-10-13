using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Data.Cart;
using bookstore_mvc.Data.Services;
using bookstore_mvc.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class OrdersController : Controller
  {
    private readonly IBooksService _booksService;
    private readonly ShoppingCart _shoppingCart;
    // private readonly IOrdersService _ordersService;

    public OrdersController(IBooksService booksService, ShoppingCart shoppingCart/*, IOrdersService ordersService*/)
    {
      _booksService = booksService;
      _shoppingCart = shoppingCart;
      //   _ordersService = ordersService;
    }

    [HttpGet("Orders")]
    public IActionResult ShoppingCart()
    {
      var items = _shoppingCart.GetShoppingCartItems();
      _shoppingCart.ShoppingCartItems = items;

      var response = new ShoppingCartVM()
      {
        ShoppingCart = _shoppingCart,
        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
      };

      return View(response);
    }

    [HttpGet("AddItemToShoppingCart")]
    public async Task<IActionResult> AddItemToShoppingCart(int id)
    {
      var book = await _booksService.GetBookByIdAsync(id);

      if (book != null)
      {
        _shoppingCart.AddItemToCart(book);
      }
      return base.RedirectToAction(nameof(Data.Cart.ShoppingCart));
    }

    public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
    {
      var book = await _booksService.GetBookByIdAsync(id);

      if (book != null)
      {
        _shoppingCart.RemoveItemFromCart(book);
      }
      return RedirectToAction(nameof(ShoppingCart));
    }



    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //   return View("Error!");
    // }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_mvc.Data.ViewComponents
{
  public class DisplayQuantity : ViewComponent
  {
    private readonly ShoppingCart _shoppingCart;
    public DisplayQuantity(ShoppingCart shoppingCart)
    {
      _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
      var books = _shoppingCart.GetShoppingCartItems();

      return View(books.Count);
    }
  }
}
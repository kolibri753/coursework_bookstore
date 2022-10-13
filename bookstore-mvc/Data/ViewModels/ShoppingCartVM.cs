using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Data.Cart;

namespace bookstore_mvc.Data.ViewModels
{
  public class ShoppingCartVM
  {
    public ShoppingCart? ShoppingCart { get; set; }
    public double ShoppingCartTotal { get; set; }
  }
}
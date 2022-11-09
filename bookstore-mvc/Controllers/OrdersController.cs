using System.Security.Claims;
using bookstore_mvc.Data.Cart;
using bookstore_mvc.Data.Services;
using bookstore_mvc.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class OrdersController : Controller
  {
    private readonly IBooksService _booksService;
    private readonly ShoppingCart _shoppingCart;
    private readonly IOrdersService _ordersService;

    public OrdersController(IBooksService booksService, ShoppingCart shoppingCart, IOrdersService ordersService)
    {
      _booksService = booksService;
      _shoppingCart = shoppingCart;
      _ordersService = ordersService;
    }

    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
      string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      string userRole = User.FindFirstValue(ClaimTypes.Role);

      var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
      return View(orders);
    }

    [HttpGet("ShoppingCart")]
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

    [HttpGet("CompleteOrder")]
    public async Task<IActionResult> CompleteOrder()
    {
      var items = _shoppingCart.GetShoppingCartItems();
      string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

      await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
      await _shoppingCart.ClearShoppingCartAsync();

      return View("OrderSuccess");
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //   return View("Error!");
    // }
  }
}
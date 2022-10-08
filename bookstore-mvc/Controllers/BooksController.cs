using bookstore_mvc.Data.Services;
using bookstore_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class BooksController : Controller
  {
    private readonly IBooksService _service;

    public BooksController(IBooksService service)
    {
      _service = service;
    }

    // [HttpGet("all")]
    // public async Task<ActionResult<List<Book>>> GetBooks()
    // {
    //     return await _context.Books.ToListAsync();
    // }

    // [HttpGet("{Id}")]
    // public async Task<ActionResult<Book>> GetBook(int Id)
    // {
    //     return await _context.Books.FindAsync(Id);
    // }

    public async Task<IActionResult> Index()
    {
      var data = await _service.GetAllAsync();
      return View(data);
    }

    //Get: Books/Create
    [HttpGet("Create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([Bind("ImageURL,Title,Pages,Price,Quantity,Genre,Author")] Book book)
    {
      if (!ModelState.IsValid)
      {
        return View(book);
      }
      await _service.AddAsync(book);
      return RedirectToAction(nameof(Index));
    }

    [HttpGet("Info/{id}")]
    public async Task<IActionResult> Info(int id)
    {
      var bookInfo = await _service.GetByIdAsync(id);

      if (bookInfo == null)
      {
        return View("NotFound");
      }

      return View(bookInfo);
    }

    //Get: Books/Edit/id
    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
      var bookInfo = await _service.GetByIdAsync(id);

      if (bookInfo == null)
      {
        return View("NotFound");
      }

      return View(bookInfo);
    }

    [HttpPost]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL,Title,Pages,Price,Quantity,Genre,Author")] Book book)
    {
      if (!ModelState.IsValid)
      {
        return View(book);
      }
      await _service.UpdateAsync(id, book);
      return RedirectToAction(nameof(Index));
    }


    //Get: Books/Delete/1
    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var bookInfo = await _service.GetByIdAsync(id);

      if (bookInfo == null)
      {
        return View("NotFound");
      }

      return View(bookInfo);
    }

    [HttpPost, ActionName("Delete")]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var bookInfo = await _service.GetByIdAsync(id);

      if (bookInfo == null)
      {
        return View("NotFound");
      }

      await _service.DeleteAsync(id);
      return RedirectToAction(nameof(Index));
    }

    

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //   return View("Error!");
    // }
  }
}
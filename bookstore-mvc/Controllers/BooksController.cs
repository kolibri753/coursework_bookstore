using bookstore_mvc.Data.Services;
using bookstore_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    // public async Task<IActionResult> Index()
    // {
    //   var allBooks = await _service.GetAllAsync(n => n.Author);
    //   return View(allBooks);
    // }


    public async Task<IActionResult> Search(string searchString)
    {
      var allBooks = await _service.GetAllAsync(n => n.Author);
      var dropdownsData = await _service.GetBookDroupownMenuValues();

      ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "Name");
      ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

      if (!string.IsNullOrEmpty(searchString))
      {
        var searchBooks = allBooks.Where(n => n.Title.Contains(searchString) || n.Author.Name.Contains(searchString)).ToList();
        if (searchBooks.Any())
        {
          return View("Index", searchBooks);
        }
        else
        {
          return View("NotFound");
        }

      }

      return View("Index", allBooks);
    }

    //Get: Books/Create
    [HttpGet("Create")]
    public async Task<IActionResult> Create()
    {
      var dropdownsData = await _service.GetBookDroupownMenuValues();

      ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "Name");
      ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

      return View();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(NewBookVM book)
    {
      if (!ModelState.IsValid)
      {
        var dropdownsData = await _service.GetBookDroupownMenuValues();

        ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "Name");
        ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

        return View(book);
      }

      await _service.AddNewBookAsync(book);
      return RedirectToAction(nameof(Index));
    }

    // [HttpPost]
    // [Route("Create")]
    // public async Task<IActionResult> Create([Bind("ImageURL,Title,Pages,Price,Quantity,Genre,Author")] Book book)
    // {
    //   if (!ModelState.IsValid)
    //   {
    //     return View(book);
    //   }
    //   await _service.AddAsync(book);
    //   return RedirectToAction(nameof(Index));
    // }

    [HttpGet("Info/{id}")]
    public async Task<IActionResult> Info(int id)
    {
      var bookInfo = await _service.GetBookByIdAsync(id);

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
      var bookInfo = await _service.GetBookByIdAsync(id);

      if (bookInfo == null)
      {
        return View("NotFound");
      }

      var response = new NewBookVM()
      {
        Id = bookInfo.Id,
        ImageURL = bookInfo.ImageURL,
        Title = bookInfo.Title,
        Pages = bookInfo.Pages,
        Price = bookInfo.Price,
        Quantity = bookInfo.Quantity,
        Genre = bookInfo.Genre,
        AuthorId = bookInfo.AuthorId,
        PublisherId = bookInfo.PublisherId
      };

      var dropdownsData = await _service.GetBookDroupownMenuValues();

      ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "Name");
      ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

      return View(response);
    }

    [HttpPost]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, NewBookVM book)
    {
      if (id != book.Id)
      {
        return View("NotFound");
      }

      if (!ModelState.IsValid)
      {
        var dropdownsData = await _service.GetBookDroupownMenuValues();

        ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "Name");
        ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

        return View(book);
      }

      await _service.UpdateBookAsync(book);
      return RedirectToAction(nameof(Index));
    }

    // [HttpPost]
    // [Route("Edit/{id}")]
    // public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL,Title,Pages,Price,Quantity,Genre,Author")] Book book)
    // {
    //   if (!ModelState.IsValid)
    //   {
    //     return View(book);
    //   }
    //   await _service.UpdateAsync(id, book);
    //   return RedirectToAction(nameof(Index));
    // }


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
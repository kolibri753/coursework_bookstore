using bookstore_mvc.Data.Services;
using bookstore_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class AuthorsController : Controller
  {
    private readonly IAuthorsService _service;

    public AuthorsController(IAuthorsService service)
    {
      _service = service;
    }

    public async Task<IActionResult> Index()
    {
      var allAuthors = await _service.GetAllAsync();
      return View(allAuthors);
    }

    [HttpGet("Info/{id}")]
    public async Task<IActionResult> Info(int id)
    {
      var authorInfo = await _service.GetAuthorByIdAsync(id);

      if (authorInfo == null)
      {
        return View("NotFound");
      }

      return View(authorInfo);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([Bind("ImageURL,Name,Biography")] Author author)
    {
      if (!ModelState.IsValid)
      {
        return View(author);
      }
      await _service.AddAsync(author);
      
      return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
      var authorInfo = await _service.GetByIdAsync(id);
      if (authorInfo == null) return View("NotFound");
      return View(authorInfo);
    }

    [HttpPost]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL,Name,Biography")] Author author)
    {
      if (!ModelState.IsValid) return View(author);

      if (id == author.Id)
      {
        await _service.UpdateAsync(id, author);
        return RedirectToAction(nameof(Index));
      }
      return View(author);
    }

    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var authorInfo = await _service.GetAuthorByIdAsync(id);
      if (authorInfo == null) return View("NotFound");
      return View(authorInfo);
    }

    [HttpPost, ActionName("Delete")]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var authorInfo = await _service.GetAuthorByIdAsync(id);
      if (authorInfo == null) return View("NotFound");

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
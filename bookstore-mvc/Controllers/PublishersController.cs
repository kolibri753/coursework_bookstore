using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bookstore_mvc.Data.Services;
using bookstore_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookstore_mvc.Controllers
{
  [Route("[controller]")]
  public class PublishersController : Controller
  {
    private readonly IPublishersService _service;

    public PublishersController(IPublishersService service)
    {
      _service = service;
    }

    public async Task<IActionResult> Index()
    {
      var allPublishers = await _service.GetAllAsync();
      return View(allPublishers);
    }

    [HttpGet("Info/{id}")]
    public async Task<IActionResult> Info(int id)
    {
      var publisherInfo = await _service.GetPublisherByIdAsync(id);

      if (publisherInfo == null)
      {
        return View("NotFound");
      }

      return View(publisherInfo);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([Bind("ImageURL,Name,About")] Publisher publisher)
    {
      if (!ModelState.IsValid)
      {
        return View(publisher);
      }
      await _service.AddAsync(publisher);

      return RedirectToAction(nameof(Index));
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
      var publisherInfo = await _service.GetByIdAsync(id);
      if (publisherInfo == null) return View("NotFound");
      return View(publisherInfo);
    }

    [HttpPost]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL,Name,About")] Publisher publisher)
    {
      if (!ModelState.IsValid) return View(publisher);

      if (id == publisher.Id)
      {
        await _service.UpdateAsync(id, publisher);
        return RedirectToAction(nameof(Index));
      }
      return View(publisher);
    }

    [HttpGet("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var publisherInfo = await _service.GetPublisherByIdAsync(id);
      if (publisherInfo == null) return View("NotFound");
      return View(publisherInfo);
    }

    [HttpPost, ActionName("Delete")]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var publisherInfo = await _service.GetPublisherByIdAsync(id);
      if (publisherInfo == null) return View("NotFound");

      await _service.DeleteAsync(id);
      return RedirectToAction(nameof(Index));
    }

  }
}
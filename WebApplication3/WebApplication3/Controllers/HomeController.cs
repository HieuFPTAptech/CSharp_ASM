using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class HomeController : Controller
{
    private readonly crudDatabaseContext _context;

    public HomeController(crudDatabaseContext context)
    {
        _context = context;
    }

    
    public IActionResult Index()
    {
        var comicBooks = _context.ComicBooks.ToList();
        return View(comicBooks);
    }

    
    public IActionResult Details(int id)
    {
        var comicBook = _context.ComicBooks.FirstOrDefault(cb => cb.ComicBookID == id);
        if (comicBook == null)
        {
            return NotFound();
        }
        return View(comicBook);
    }

    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Title,Author,PricePerDay")] ComicBook comicBook)
    {
        if (ModelState.IsValid)
        {
            _context.ComicBooks.Add(comicBook);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    
    public IActionResult Edit(int id)
    {
        var comicBook = _context.ComicBooks.FirstOrDefault(cb => cb.ComicBookID == id);
        if (comicBook == null)
        {
            return NotFound();
        }
        return View(comicBook);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("ComicBookID,Title,Author,PricePerDay")] ComicBook comicBook)
    {
        if (id != comicBook.ComicBookID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.ComicBooks.Update(comicBook);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    
    public IActionResult Delete(int id)
    {
        var comicBook = _context.ComicBooks.FirstOrDefault(cb => cb.ComicBookID == id);
        if (comicBook == null)
        {
            return NotFound();
        }
        return View(comicBook);
    }

    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var comicBook = _context.ComicBooks.Find(id);
        if (comicBook != null)
        {
            _context.ComicBooks.Remove(comicBook);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}

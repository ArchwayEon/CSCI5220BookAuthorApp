using CSCI5220BookAuthorApp.Models.ViewModels;
using CSCI5220BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSCI5220BookAuthorApp.Controllers;

public class AuthorController : Controller
{
    private IBookRepository _bookRepo;

    public AuthorController(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IActionResult Create([Bind(Prefix = "id")] int bookId)
    {
        var book = _bookRepo.Read(bookId);
        if (book == null)
        {
            return RedirectToAction("Index", "Book");
        }
        ViewData["Book"] = book;
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(int bookId, CreateAuthorVM authorVM)
    {
        if (ModelState.IsValid)
        {
            var author = authorVM.GetAuthorInstance();
            _bookRepo.CreateAuthor(bookId, author);
            return RedirectToAction("Details", "Book", new { id = bookId });
        }
        ViewData["Book"] = _bookRepo.Read(bookId);
        return View(authorVM);
    }

    public IActionResult Edit([Bind(Prefix = "id")] int bookId, int authorId)
    {
        var book = _bookRepo.Read(bookId);
        if (book == null)
        {
            return RedirectToAction("Index", "Book");
        }
        var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
        if (author == null)
        {
            return RedirectToAction("Details", "Book", new { id = bookId });
        }
        var model = new EditAuthorVM
        {
            Book = book,
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int bookId, EditAuthorVM authorVM)
    {
        if (ModelState.IsValid)
        {
            _bookRepo.UpdateAuthor(bookId, authorVM.GetAuthorInstance());
            return RedirectToAction("Details", "Book", new { id = bookId });
        }
        authorVM.Book = _bookRepo.Read(bookId);
        return View(authorVM);
    }

    public IActionResult Delete([Bind(Prefix = "id")] int bookId, int authorId)
    {
        var book = _bookRepo.Read(bookId);
        if (book == null)
        {
            return RedirectToAction("Index", "Book");
        }
        var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
        if (author == null)
        {
            return RedirectToAction("Details", "Book", new { id = bookId });
        }
        var model = new DeleteAuthorVM
        {
            Book = book,
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int bookId, int authorId)
    {
        _bookRepo.DeleteAuthor(bookId, authorId);
        return RedirectToAction("Details", "Book", new { id = bookId });
    }

}

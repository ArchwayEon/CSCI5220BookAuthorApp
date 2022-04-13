using CSCI5220BookAuthorApp.Models.ViewModels;
using CSCI5220BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSCI5220BookAuthorApp.Controllers;

public class BookController : Controller
{
    private IBookRepository _bookRepo;

    public BookController(IBookRepository BookRepo)
    {
        _bookRepo = BookRepo;
    }

    public IActionResult Index()
    {
        var allBooks = _bookRepo.ReadAll();
        var model = allBooks.Select(b =>
           new BookDetailsVM
           {
               Id = b.Id,
               Title = b.Title,
               PublicationYear = b.PublicationYear,
               NumberOfAuthors = b.Authors.Count
           });
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(CreateBookVM bookVM)
    {
        if (ModelState.IsValid)
        {
            var book = bookVM.GetBookInstance();
            _bookRepo.Create(book);
            return RedirectToAction("Index");
        }
        return View(bookVM);
    }

    public IActionResult Details(int id)
    {
        var book = _bookRepo.Read(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        var model = new BookDetailsVM
        {
            Id = book.Id,
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            NumberOfAuthors = book.Authors.Count,
            Authors = book.Authors
        };
        return View(model);
    }


}

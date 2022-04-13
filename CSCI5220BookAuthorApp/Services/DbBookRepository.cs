using CSCI5220BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI5220BookAuthorApp.Services;

public class DbBookRepository : IBookRepository
{
    private ApplicationDbContext _db;

    public DbBookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Book Create(Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
        return book;
    }

    public Author CreateAuthor(int bookId, Author author)
    {
        var book = Read(bookId);
        if (book != null)
        {
            book.Authors.Add(author);
            author.Book = book;
            _db.SaveChanges();
        }
        return author;
    }

    public void DeleteAuthor(int bookId, int authorId)
    {
        var book = Read(bookId);
        if(book != null)
        {
            var authorToDelete = book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (authorToDelete != null)
            {
                book.Authors.Remove(authorToDelete);
                _db.SaveChanges();
            }
        }
    }

    public Book? Read(int id)
    {
        return _db.Books
            .Include(b => b.Authors)
            .FirstOrDefault(b => b.Id == id);
    }

    public ICollection<Book> ReadAll()
    {
        return _db.Books.Include(b => b.Authors).ToList();
    }

    public void UpdateAuthor(int bookId, Author author)
    {
        var book = Read(bookId);
        if(book != null)
        {
            var authorToUpdate = book.Authors
                .FirstOrDefault(a => a.Id == author.Id);
            if(authorToUpdate != null)
            {
                authorToUpdate.FirstName = author.FirstName;
                authorToUpdate.LastName = author.LastName;
                _db.SaveChanges();
            }
        }
    }
}

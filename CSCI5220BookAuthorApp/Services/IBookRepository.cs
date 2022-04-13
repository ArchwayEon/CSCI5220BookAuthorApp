using CSCI5220BookAuthorApp.Models.Entities;

namespace CSCI5220BookAuthorApp.Services;

public interface IBookRepository
{
    Book Create(Book book);
    ICollection<Book> ReadAll();
    Book? Read(int id);
    Author CreateAuthor(int bookId, Author author);
    void UpdateAuthor(int bookId, Author author);
    void DeleteAuthor(int bookId, int authorId);
}

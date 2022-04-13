using CSCI5220BookAuthorApp.Models.Entities;
using System.ComponentModel;

namespace CSCI5220BookAuthorApp.Models.ViewModels;

public class EditAuthorVM
{
    public Book? Book { get; set; }
    public int Id { get; set; }
    [DisplayName("First Name")]
    public string FirstName { get; set; } = String.Empty;
    [DisplayName("Last Name")]
    public string LastName { get; set; } = String.Empty;

    public Author GetAuthorInstance()
    {
        return new Author
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName
        };
    }
}

using CSCI5220BookAuthorApp.Models.Entities;
using System.ComponentModel;

namespace CSCI5220BookAuthorApp.Models.ViewModels;

public class CreateBookVM
{
    public string Title { get; set; } = String.Empty;
    [DisplayName("Publication Year")]
    public int PublicationYear { get; set; }

    public Book GetBookInstance()
    {
        return new Book
        {
            Id = 0,
            Title = Title,
            PublicationYear = PublicationYear
        };
    }
}

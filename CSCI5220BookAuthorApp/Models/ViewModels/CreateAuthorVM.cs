using CSCI5220BookAuthorApp.Models.Entities;
using System.ComponentModel;

namespace CSCI5220BookAuthorApp.Models.ViewModels;

public class CreateAuthorVM
{
    [DisplayName("First Name")]
    public string FirstName { get; set; } = String.Empty;
    [DisplayName("Last Name")]
    public string LastName { get; set; } = String.Empty;
    public Author GetAuthorInstance()
    {
        return new Author
        {
            Id = 0,
            FirstName = this.FirstName,
            LastName = this.LastName
        };
    }
}

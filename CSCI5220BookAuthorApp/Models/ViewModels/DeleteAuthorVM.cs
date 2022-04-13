using CSCI5220BookAuthorApp.Models.Entities;

namespace CSCI5220BookAuthorApp.Models.ViewModels;

public class DeleteAuthorVM
{
  public Book? Book { get; set; }
  public int Id { get; set; }
  public string FirstName { get; set; } = String.Empty;
  public string LastName { get; set; } = String.Empty;
}

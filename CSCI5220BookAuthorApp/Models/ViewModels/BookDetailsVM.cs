using CSCI5220BookAuthorApp.Models.Entities;
using System.ComponentModel;

namespace CSCI5220BookAuthorApp.Models.ViewModels;

public class BookDetailsVM
{
  public int Id { get; set; }
  public string Title { get; set; } = String.Empty;
  [DisplayName("Publication Year")]
  public int PublicationYear { get; set; }
  [DisplayName("Number of Authors")]
  public int NumberOfAuthors { get; set; }
  public ICollection<Author> Authors { get; set; }
    = new List<Author>();
}

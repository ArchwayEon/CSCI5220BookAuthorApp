using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSCI5220BookAuthorApp.Models.Entities;

public class Book
{
    public int Id { get; set; }
    [Required, StringLength(256)]
    public string Title { get; set; } = String.Empty;
    public int PublicationYear { get; set; }
    public ICollection<Author> Authors { get; set; }
        = new List<Author>();
}

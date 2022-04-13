using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSCI5220BookAuthorApp.Models.Entities;

public class Author
{
    public int Id { get; set; }
    [StringLength(128)]
    public string FirstName { get; set; } = String.Empty;
    [Required, StringLength(128)]
    public string LastName { get; set; } = String.Empty;

    public int BookId { get; set; }
    public Book? Book { get; set; }
}

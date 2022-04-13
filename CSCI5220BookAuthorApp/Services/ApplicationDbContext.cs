using CSCI5220BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI5220BookAuthorApp.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
}

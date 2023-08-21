using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Peoples { get; set; }
}
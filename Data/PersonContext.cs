using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class PersonContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public virtual DbSet<Person> Persons { get; set; }
    public PersonContext(IConfiguration configuration){
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"));
    }
}
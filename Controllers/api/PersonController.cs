using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase{
    private readonly PersonContext _dbContext;
    public PersonController(PersonContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static readonly List<App.Classes.Person> peoples = new List<App.Classes.Person>();

    [HttpGet]
    public App.Classes.Person[] List() => peoples.ToArray();


    [HttpGet("static/{id}")]
    public App.Classes.Person GetFromStaticVariablePerson(Guid id)
    {
        try
        {
            var person = peoples.Find((elt) => { return elt.Id.Equals(id);});
            _ = person ?? throw new ArgumentNullException("People is null");
            return person;
        }
        catch (System.Exception)
        {
            return new App.Classes.Person(Guid.Empty, $"No Name Found with id : {id}", DateOnly.FromDateTime(DateTime.UtcNow));
        }
    }
    [HttpGet("postgres/{id}")]
    public async Task<IActionResult> GetPersonFromPostgressById(Guid id)
    {
        try
        {
            Person? person = await _dbContext.Persons
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);
            _ = person ?? throw new ArgumentNullException();
            return Ok(person);
        }
        catch (System.Exception ex)
        {
            return BadRequest(new {message = $"Value {id} not found"});
        }
    }

    [HttpPost("addStatic/{lastName}")]
    public App.Classes.Person AddPersonToStaticVariable(String lastName){
        var newPerson = new App.Classes.Person(Guid.NewGuid(), lastName, DateOnly.FromDateTime(DateTime.UtcNow));
        peoples.Append(newPerson);
        return newPerson;
    }

    [HttpPost("addPostgres/{lastName}")]
    public async Task<IActionResult> AddPersonToPostgres(String lastName){
        try
        {
            // var newPerson = new Person(Guid.NewGuid(), lastName, DateOnly.FromDateTime(DateTime.UtcNow));
            Person newPerson = new();
            newPerson.Id = Guid.NewGuid();
            newPerson.Name = lastName;
            await _dbContext.Persons.AddAsync(newPerson);
            await _dbContext.SaveChangesAsync();
            return Ok(newPerson);
        }
        catch (System.Exception ex)
        {
            return BadRequest(new {message = $"db error when adding {lastName}"});
        }
    }
}
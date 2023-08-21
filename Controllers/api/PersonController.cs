using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase{
    private readonly PersonContext _dbContext;
    public PersonController(PersonContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static readonly List<Person> peoples = new List<Person>();

    [HttpGet]
    public Person[] List() => peoples.ToArray();

    [HttpGet("{id}")]
    public Person GetPeople(Guid id)
    {
        try
        {
            var person = peoples.Find(elt => elt.Id.Equals(id));
            _ = person ?? throw new ArgumentNullException("People is null");
            return person;
        }
        catch (System.Exception)
        {
            return new Person(Guid.Empty, $"No Name Found with id : {id}", DateOnly.FromDateTime(DateTime.UtcNow));
        }
    }

    [HttpPost("add/{lastName}")]
    public Person AddPeople(String lastName){
        Person newPerson = new Person(Guid.NewGuid(), lastName, DateOnly.FromDateTime(DateTime.UtcNow));
        peoples.Add(newPerson);
        _dbContext.People.Add(newPerson);
        _dbContext.SaveChanges();
        return newPerson;
    }
}
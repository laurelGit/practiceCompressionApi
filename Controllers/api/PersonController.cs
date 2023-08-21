using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase{

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
        var newPerson = new Person(Guid.NewGuid(), lastName, DateOnly.FromDateTime(DateTime.UtcNow));
        peoples.Add(newPerson);
        return newPerson;
    }
}
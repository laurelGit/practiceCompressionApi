using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase{

    [HttpGet(Name = "/person")]
    public Person[] List(){
        Person[] poeples = new Person[]{
            new Person( "Michel", new DateOnly(2023,01,01)),
            new Person( "Wilfried", new DateOnly(2023,01,01)),
            new Person( "Laurel", new DateOnly(2023,01,01)),
        };
        return poeples;
    }
}
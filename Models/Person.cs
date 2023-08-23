namespace App.Models;

public class Person{
    public Guid Id { get; set; } = Guid.Empty;
    public String Name {get; set;} = "";
    public DateOnly DateNaiss { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

}
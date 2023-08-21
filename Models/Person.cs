namespace App;

public class Person{
    public Guid Id { get; set; }
    public DateOnly DateNaiss { get; set; }
    public String Name {get; set;}
    public Person(Guid id, String name, DateOnly DateNaiss){
        this.Id = id;
        this.Name = name;
        this.DateNaiss = DateNaiss;
    }
}
using System.Collections.ObjectModel;
using System.Xml;

namespace App;

public class Person{
    public Guid Id { get; set; }
    public DateOnly DateNaiss { get; set; }
    public String Name {get; set;}
    public Person(String name, DateOnly DateNaiss){
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.DateNaiss = DateNaiss;
    }
}
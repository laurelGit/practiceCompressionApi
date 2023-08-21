using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace App.Classes;

public class Person{
    [key]
    private Guid Id { get; set; }
    [required]
    private String Name {get; set;}
    [Column(TypeName="date")]
    private DateOnly DateNaiss { get; set; }
    public Person(Guid id, String name, DateOnly DateNaiss){
        this.Id = id;
        this.Name = name;
        this.DateNaiss = DateNaiss;
    }
}
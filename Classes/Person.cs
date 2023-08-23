using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace App.Classes;

public class Person{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public String Name {get; set;}
    [Column(TypeName="date")]
    public DateOnly DateNaiss { get; set; }
    public Person(Guid id, String name, DateOnly DateNaiss){
        this.Id = id;
        this.Name = name;
        this.DateNaiss = DateNaiss;
    }
}
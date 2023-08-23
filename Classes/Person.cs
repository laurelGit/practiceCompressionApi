using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace App.Classes;

public class Person{
    [Key]
    private Guid Id { get; set; }
    public Guid GetId(){
        return Id;
    }
    public void SetId(Guid Id){
        this.Id = Id;
    }
    [Required]
    private String Name {get; set;}
    public String GetName(){
        return Name;
    }
    public void SetName(String Name){
        this.Name = Name;
    }
    [Column(TypeName="date")]
    private DateOnly DateNaiss { get; set; }
    public Person(Guid id, String name, DateOnly DateNaiss){
        this.Id = id;
        this.Name = name;
        this.DateNaiss = DateNaiss;
    }
}
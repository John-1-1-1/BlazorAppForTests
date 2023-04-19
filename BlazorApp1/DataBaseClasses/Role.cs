using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.DataBaseClasses; 

public class Role {

    [Key] 
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<User>? User { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.DataBaseClasses; 

public class User {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    [Required]
    public string Login { get; set; } = "";
    [Required]
    public string HashPass { get; set; } = "";
}
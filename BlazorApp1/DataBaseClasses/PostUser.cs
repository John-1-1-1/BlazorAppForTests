using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.DataBaseClasses; 

public class PostUser {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Пустое поле")]
    public string PostName { get; set; } = "";
    public List<User>? User { get; set; }
}
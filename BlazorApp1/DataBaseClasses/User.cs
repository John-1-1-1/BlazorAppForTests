using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.DataBaseClasses; 

public class User {
    public User() {
    }

    public int Id { get; set; }
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Логин не введён")]
    public string Login { get; set; } = "";
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Длина пароля не менее 8-ми и не более 100 символов")]
    public string Pass { get; set; } = "";

    public string Role { get; set; } = "";
}
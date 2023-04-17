using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.DataBaseClasses; 

public class User {
    public User() {
        IsExistUser = false;
    }

    public int Id { get; set; }
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Логин не введён")]
    public string Login { get; set; } = "";
    [StringLength(50, MinimumLength = 8, ErrorMessage = "Длина пароля не менее 8-ми и не более 50-ти символов")]
    public string Pass { get; set; } = "";

    [Range(typeof(bool), "true", "true",
        ErrorMessage = "This form disallows unapproved ships.")]

    private bool _isExistUser = false;
    public bool IsExistUser {
        get { return _isExistUser; }
        set { _isExistUser = value; }
    }
}
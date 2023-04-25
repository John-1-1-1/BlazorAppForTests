using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.DataBaseClasses; 

public class User {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Пустое поле")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Пустое поле")]
    public string LastName { get; set; } = "";
    
    public string MiddleName { get; set; } = "";

    [Required(ErrorMessage = "Логин не введён")]
    public string Login { get; set; } = "";
    [Required(ErrorMessage = "Пустое поле")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Длина пароля не менее 8-ми и не более 100 символов")]
    public string Pass { get; set; } = "";
    [Range(1,Int32.MaxValue, ErrorMessage = "Должность не выбрана")]
    public int PostId { get; set; }
    [ForeignKey("PostId")]
    public PostUser? Post { get; set; }

    [Range(1,Int32.MaxValue, ErrorMessage = "Роль не выбрана")]
    public int RoleId { get; set; } 
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
}
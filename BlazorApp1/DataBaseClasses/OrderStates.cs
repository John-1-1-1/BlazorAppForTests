using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.DataBaseClasses; 

public class OrderStates {
    [Key]
    public int Id { get; set; }
    public int StateOrder { get; set; }
    [Range(0, Int32.MaxValue)]
    public int? UserId { get; set; } 
    [ForeignKey("UserId")]
    public User? User { get; set; }

    public List<Order> Orders { get; set; }
}

public static class States {
    public static List<(int id, string name, string color)> ListStates = new List<(int id, string name, string color)>()
    {
        (1, "Взять", "bg-primary"),
        (2, "Выполняется", "bg-secondary"),
        (3, "Завершена", "bg-success")
    };
}
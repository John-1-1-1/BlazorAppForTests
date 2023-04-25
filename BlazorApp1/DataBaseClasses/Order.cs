using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.DataBaseClasses; 

public class Order {
    [Key]
    public int Id { get; set; }

    public string Header { get; set; } = "";

    public string Description { get; set; } = "";

    public string ImagePath { get; set; } = "";

    public int UserId { get; set; } 
    [ForeignKey("UserId")]
    public User? User { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Versioning;

namespace BlazorApp1.DataBaseClasses; 

public class Order {

    [Key]
    public int Id { get; set; }

    [Required]
    public string Header { get; set; } = "";

    [Required]
    public string Description { get; set; } = "";
    
    public string ImagePath { get; set; } = "";

    [Range(0, Int32.MaxValue)]
    public int UserId { get; set; } 
    [ForeignKey("UserId")]
    public User? User { get; set; }

    [Range(0, Int32.MaxValue)]
    public int OrderStateId { get; set; } 
    [ForeignKey("OrderStateId")]
    public OrderStates? OrderState { get; set; }

}
using System.ComponentModel.DataAnnotations;

namespace service.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public double ProductName { get; set; }
    [Range(0, 10000)]
    public int ProductPrice { get; set; }
    public string ProductCategory { get; set; }
    public string ProductDescription { get; set; }
}
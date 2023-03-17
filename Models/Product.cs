using System.ComponentModel.DataAnnotations;

namespace service.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Range(0, 10000)]
    public double ProductPrice { get; set; }
    public string ProductCategory { get; set; }
    public string ProductDescription { get; set; }
}
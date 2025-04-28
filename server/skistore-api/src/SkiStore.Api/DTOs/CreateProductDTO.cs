using System.ComponentModel.DataAnnotations;

namespace SkiStore.Api.DTOs;

public class CreateProductDTO
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }
    
    [Required]
    public string PictureUrl { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public string Brand { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity in stock must be at least one.")]
    public int QuantityInStock { get; set; }
}

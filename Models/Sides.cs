using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Side
  {
    public int Id { get; set; }

    [Required]
    public string InspiredBy { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public double Price { get; set; }
  }

}
using System;
using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    public int Id { get; set; }

    [Required]
    public string InspiredBy { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public double Price { get; set; }


    // CTOR is only needed for FAKEDB
    public Burger(string name, string description, double price)
    {
      // Id = Guid.NewGuid().ToString();
      Name = name;
      Description = description;
      Price = Price;
    }

    public Burger()
    {
      // Id = Guid.NewGuid().ToString();
    }
  }
}
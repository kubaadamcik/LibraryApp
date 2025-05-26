using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public required string Title { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Author { get; set; }
    [Required]
    [MaxLength(250)]
    public required string Description { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
}
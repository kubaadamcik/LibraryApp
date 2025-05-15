using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.ValueObjects;

namespace Library.Domain.Entities;

public class Reader
{ 
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}
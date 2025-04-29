using Library.Domain.ValueObjects;

namespace Library.Domain.Entities;

public class User
{ 
    // TODO: Complete the class
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; }
    
    public virtual ReaderInfo ReaderInfo { get; set; }
}
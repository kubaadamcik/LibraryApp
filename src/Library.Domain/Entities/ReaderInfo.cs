using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities;

public class ReaderInfo
{
    public int UserId { get; set; }
    public int CurrentCountOfBorrowedBooks { get; set; }
    public int BorrowedBooksCount { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}
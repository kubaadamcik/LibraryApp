using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities;

public class BookTransaction
{
    public int Id { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; } = null;
    public bool IsReturned { get; set; }
    
    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }
    
    public int ReaderId { get; set; }
    [ForeignKey("ReaderId")]
    public virtual Reader Reader { get; set; }

    public BookTransaction()
    {
        BorrowedDate = DateTime.Now;
        IsReturned = false;
    }
    
    public void Return()
    {
        ReturnedDate = DateTime.Now;
        IsReturned = true;
    }
}
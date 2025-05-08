using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities;

public class ReaderInfo
{
    public int Id { get; set; } // Dal jsem to tu protože nešla udělat migrace bez toho
    
    public int CurrentCountOfBorrowedBooks { get; set; } = 0;
    public int BorrowedBooksCount { get; set; }

    public int UserId { get; set; }
    public virtual Reader Reader { get; set; }
}
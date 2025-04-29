using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities;

public class ReaderInfo
{
    // TODO: Added foreign key attribute to the userid property
    public int UserId { get; set; }
    public int CurrentCountOfBorrowedBooks { get; set; }
    public int BorrowedBooksCount { get; set; }

    public virtual User User { get; set; }
}
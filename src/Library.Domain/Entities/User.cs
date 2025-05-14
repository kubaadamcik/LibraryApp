namespace Library.Domain.Entities;

public class User
{
    public int Id { get; set; }

    // TODO: Správce, zaměstnanec v knihovně...
    
    // ...
    public virtual Reader Reader { get; set; }
}
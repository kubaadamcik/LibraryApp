using System.Text.RegularExpressions;

namespace Library.Domain.ValueObjects;

public class Email
{
    private string Address { get; set; } = string.Empty;

    public bool SetAddress(string? address)
    {
        if (string.IsNullOrWhiteSpace(address)) return false;
        
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            
        // Additional checks for common email constraints
        if (address.Length > 254) // Max length for email addresses
            return false;

        if (!Regex.IsMatch(address, pattern, RegexOptions.IgnoreCase)) return false;
        Address = address;
        return true;
    }

    public string GetAddress() => Address;
    
    public override string ToString() => Address;
}
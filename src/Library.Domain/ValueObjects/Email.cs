using System.Text.RegularExpressions;

namespace Library.Domain.ValueObjects;

public static class Email
{

    public static bool IsValid(string address)
    {
        if (string.IsNullOrWhiteSpace(address)) return false;
        
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            
        if (address.Length > 254)
            return false;

        if (!Regex.IsMatch(address, pattern, RegexOptions.IgnoreCase)) return false;
        return true;
    }
}
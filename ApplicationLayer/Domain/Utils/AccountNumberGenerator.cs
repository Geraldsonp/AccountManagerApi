namespace ApplicationLayer.Domain.Utils;

public static class AccountNumberGenerator
{
    public static string GenerateRandomAccountNumber()
    {
        Random random = new Random();

        
        int accountNumberLength = 10;

       
        string digits = "";
        for (int i = 0; i < accountNumberLength; i++)
        {
            digits += random.Next(0, 10); 
        }

        
        string formattedAccountNumber = $"ACCT-{digits.Substring(0, 3)}-{digits.Substring(3, 3)}-{digits.Substring(6)}";

        return formattedAccountNumber;
    }
}
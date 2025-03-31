using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class ImportantClientType : IClientType
{
    public void ApplyCreditLimit(User user, IUserCreditService creditService)
    {
        int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        creditLimit = creditLimit * 2;
        user.CreditLimit = creditLimit;
    }
}
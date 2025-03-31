using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class DefaultClientType : IClientType
{
    public void ApplyCreditLimit(User user, IUserCreditService creditService)
    {
        user.HasCreditLimit = true;
        int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        user.CreditLimit = creditLimit;
    }
}
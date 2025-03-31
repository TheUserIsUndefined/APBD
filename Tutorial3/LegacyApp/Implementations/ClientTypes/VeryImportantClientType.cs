using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class VeryImportantClientType : IClientType
{
    public void ApplyCreditLimit(User user, IUserCreditService creditService)
    {
        user.HasCreditLimit = false;
    }
}
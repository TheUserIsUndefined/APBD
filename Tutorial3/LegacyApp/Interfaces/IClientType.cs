namespace LegacyApp.Interfaces;

public interface IClientType
{ 
    void ApplyCreditLimit(User user, IUserCreditService creditService);
}
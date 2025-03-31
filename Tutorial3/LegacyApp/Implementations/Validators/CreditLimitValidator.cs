using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class CreditLimitValidator : IValidator<User>
{
    private readonly int _minCreditLimit;
    private readonly IUserCreditService _userCreditService;
    private readonly Dictionary<string, IClientType> _clientTypes;
    
        
    public CreditLimitValidator(int minCreditLimit = 500,
        IUserCreditService? creditService = null,
        Dictionary<string, IClientType>? clientTypes = null)
    {
        _minCreditLimit = minCreditLimit;
        _userCreditService = creditService ?? new UserCreditService();
        _clientTypes = clientTypes ?? new Dictionary<string, IClientType>()
        {
            { "VeryImportantClient", new VeryImportantClientType() },
            { "ImportantClient", new ImportantClientType() },
            { "DefaultClient", new DefaultClientType() }
        };
    }
    
    public bool Validate(User user)
    {
        var client = user.Client;
        var clientTypeStr = client.Type;
        var clientType = _clientTypes.ContainsKey(clientTypeStr) 
            ? _clientTypes[clientTypeStr] 
            : _clientTypes["DefaultClient"];
        clientType.ApplyCreditLimit(user, _userCreditService);

        return !(user.HasCreditLimit && user.CreditLimit < _minCreditLimit);
    }
}
using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class EmailValidator : IValidator<string>
{
    public bool Validate(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}
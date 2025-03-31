using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class NameValidator : IValidator<string>
{
    public bool Validate(string name)
    {
        return !string.IsNullOrEmpty(name);
    }
}
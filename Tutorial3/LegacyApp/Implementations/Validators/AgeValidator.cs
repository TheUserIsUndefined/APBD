using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class AgeValidator : IValidator<DateTime>
{
    private readonly int _maxAge;
    public AgeValidator(int maxAge = 21)
    {
        _maxAge = maxAge;
    }
    public bool Validate(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        
        return age >= _maxAge;
    }
}
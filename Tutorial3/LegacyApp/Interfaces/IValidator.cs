namespace LegacyApp.Interfaces;

public interface IValidator<T>
{ 
    bool Validate(T toValidate);
}
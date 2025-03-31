using System;
using LegacyApp.Implementations;
using LegacyApp.Interfaces;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IValidator<string> _emailValidator;
        private readonly IValidator<string> _nameValidator;
        private readonly IValidator<DateTime> _ageValidator;
        private readonly IValidator<User> _creditLimitValidator;
        private readonly IClientRepository _clientRepository;

        public UserService(
            IValidator<string>? emailValidator = null, 
            IValidator<string>? nameValidator = null, 
            IValidator<DateTime>? ageValidator = null,
            IValidator<User>? creditLimitValidator = null,
            IClientRepository? clientRepository = null)
        {
            _emailValidator = emailValidator ?? new EmailValidator();
            _nameValidator = nameValidator ?? new NameValidator();
            _ageValidator = ageValidator ?? new AgeValidator();
            _creditLimitValidator = creditLimitValidator ?? new CreditLimitValidator();
            _clientRepository = clientRepository ?? new ClientRepository();
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_nameValidator.Validate(firstName) || !_nameValidator.Validate(lastName))
            {
                return false;
            }

            if (!_emailValidator.Validate(email))
            {
                return false;
            }

            if (!_ageValidator.Validate(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (!_creditLimitValidator.Validate(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
} 
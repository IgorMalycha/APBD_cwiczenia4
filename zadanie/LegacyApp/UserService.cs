﻿using System;

namespace LegacyApp
{
    public class UserService
    {
        private IUserCreditService _userCreditService;
        private IClientRepository _clientRepository;

        public UserService(IUserCreditService userCreditService, IClientRepository clientRepository)
        {
            _userCreditService = userCreditService;
            _clientRepository = clientRepository;
        }
        
        [Obsolete]
        public UserService()
        {
            _userCreditService = new UserCreditService();
            _clientRepository = new ClientRepository();
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
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

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                
                user.CreditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                
            }
            else
            {
                user.HasCreditLimit = true;
                
                user.CreditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}

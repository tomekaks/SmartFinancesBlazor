using AutoMapper;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Accounts.Factories
{
    public class AccountFactory : IAccountFactory
    {
        private readonly IMapper _mapper;

        public AccountFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Account CreateAccount(AccountDto accountDto)
        {
            return _mapper.Map<Account>(accountDto);
        }

        public Account CreateAccount(string userId, string accountName)
        {
            return new Account()
            {
                UserId = userId,
                Name = accountName,
                Number = GenerateAccountNumber()
            };
        }

        public AccountDto CreateAccountDto(Account account)
        {
            return _mapper.Map<AccountDto>(account);
        }

        public Account MapToModel(AccountDto accountDto, Account model)
        {
            return _mapper.Map(accountDto, model);
        }

        public Account MapToModel(UpdateAccountDto accountDto, Account model)
        {
            return _mapper.Map(accountDto, model);
        }

        private string GenerateAccountNumber()
        {
            var rand = new Random();
            var firstNumbers = rand.Next(10, 99).ToString();
            var secondNumbers = rand.Next(100000, 999999).ToString();
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = new char[4];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = alphabet[rand.Next(0, alphabet.Length - 1)];
            }

            string letters = new string(chars);

            return firstNumbers + letters + secondNumbers;
        }
    }
}

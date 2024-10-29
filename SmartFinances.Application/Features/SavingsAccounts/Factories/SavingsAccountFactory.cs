using AutoMapper;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.SavingsAccounts.Factories
{
    public class SavingsAccountFactory : ISavingsAccountFactory
    {
        private readonly IMapper _mapper;

        public SavingsAccountFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SavingsAccount CreateSavingsAccount(CreateSavingsAccountDto accountDto, string userName)
        {
            return new SavingsAccount()
            {
                Number = GenerateAccountNumber(),
                Name = userName + " - " + Constants.SAVINGSACCOUNT,
                UserId = accountDto.UserId,
                AccountTypeId = accountDto.AccountTypeId,
                CreationDateTime = DateTime.UtcNow
            };
        }

        public SavingsAccountDto CreateSavingsAccountDto(SavingsAccount savingsAccount)
        {
            return _mapper.Map<SavingsAccountDto>(savingsAccount);
        }

        private string GenerateAccountNumber()
        {
            var rand = new Random();
            var numbers = rand.Next(10000000, 99999999).ToString();
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = new char[2];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = alphabet[rand.Next(0, alphabet.Length - 1)];
            }

            string letters = new string(chars);

            return letters + numbers;
        }
    }
}

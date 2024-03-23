﻿using AutoMapper;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.TransactionalAccounts.Factories
{
    public class TransactionalAccountFactory : ITransactionalAccountFactory
    {
        private readonly IMapper _mapper;

        public TransactionalAccountFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TransactionalAccount CreateTransactionalAccount(CreateTransactionalAccountDto accountDto, string userName)
        {
            return new TransactionalAccount()
            {
                Number = GenerateAccountNumber(),
                Name = userName + " - " + accountDto.TypeName,
                UserId = accountDto.UserId,
                Type = accountDto.Type,
                Balance = 0,
                Budget = 0,
                CreationDateTime = DateTime.UtcNow
            };
        }

        public TransactionalAccountDto CreateTransactionalAccountDto(TransactionalAccount transactionalAccount)
        {
            return _mapper.Map<TransactionalAccountDto>(transactionalAccount);
        }

        public List<TransactionalAccountDto> CreateTransactionalAccountDtoList(List<TransactionalAccount> transactionalAccounts)
        {
            return _mapper.Map<List<TransactionalAccountDto>>(transactionalAccounts);
        }

        public TransactionalAccount MapToModel(UpdateTransactionalAccountDto dto, TransactionalAccount model)
        {
            return _mapper.Map(dto, model);
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
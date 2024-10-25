using AutoMapper;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Factories
{
    public class TransferFactory : ITransferFactory
    {
        private readonly IMapper _mapper;

        public TransferFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Transfer CreateTransfer(CreateTransferDto createTransferDto)
        {
            return _mapper.Map<Transfer>(createTransferDto);
        }

        public TransferDto CreateTransferDto(Transfer transfer)
        {
            return _mapper.Map<TransferDto>(transfer);
        }

        public List<TransferDto> CreateTransferDtoList(List<Transfer> transfers)
        {
            return _mapper.Map<List<TransferDto>>(transfers);
        }

        public PaginatedList<TransferDto> CreatePaginatedListOfTransfers(
            List<Transfer> transfers, int pageNumber, int pageSize, int totalPages, int totalCount)
        {
            var transfersDto = _mapper.Map<List<TransferDto>>(transfers);

            var paginatedList = new PaginatedList<TransferDto>()
            {
                Items = transfersDto,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = totalCount
            };

            return paginatedList;
        }

        public Transfer MapToModel(UpdateTransferDto updateTransferDto, Transfer transfer)
        {
            return _mapper.Map(updateTransferDto, transfer);
        }

        public Transfer MapFromWithdrawal(SavingsAccountTransferDto savingsAccountTransferDto)
        {
            return new Transfer()
            {
                Amount = savingsAccountTransferDto.Amount,
                SendTime = savingsAccountTransferDto.SendTime,
                SenderName = savingsAccountTransferDto.SavingsAccountName,
                SenderAccountNumber = savingsAccountTransferDto.SavingsAccountNumber,
                ReceiverName = savingsAccountTransferDto.TransactionalAccountName,
                ReceiverAccountNumber = savingsAccountTransferDto.TransactionalAccountNumber,
                Title = savingsAccountTransferDto.Title
            };
        }

        public Transfer MapFromDeposit(SavingsAccountTransferDto savingsAccountTransferDto)
        {
            return new Transfer()
            {
                Amount = savingsAccountTransferDto.Amount,
                SendTime = savingsAccountTransferDto.SendTime,
                SenderName = savingsAccountTransferDto.TransactionalAccountName,
                SenderAccountNumber = savingsAccountTransferDto.TransactionalAccountNumber,
                ReceiverName = savingsAccountTransferDto.SavingsAccountName,
                ReceiverAccountNumber = savingsAccountTransferDto.SavingsAccountNumber,
                Title = savingsAccountTransferDto.Title
            };
        }
    }
}

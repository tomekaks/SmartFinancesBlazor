using AutoMapper;
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

        public Transfer MapToModel(UpdateTransferDto updateTransferDto, Transfer transfer)
        {
            return _mapper.Map(updateTransferDto, transfer);
        }
    }
}

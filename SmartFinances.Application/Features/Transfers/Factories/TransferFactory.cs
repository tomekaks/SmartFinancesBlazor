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

        public Transfer CreateTransfer(OutgoingTransferDto transferDto)
        {
            return _mapper.Map<Transfer>(transferDto);
        }

        public OutgoingTransferDto CreateTransferDto(Transfer transfer)
        {
            return _mapper.Map<OutgoingTransferDto>(transfer);
        }
        public Transfer CreateTransfer(TransferDto transferDto)
        {
            return _mapper.Map<Transfer>(transferDto);
        }

        public TransferDto CreateTransferDto(Transfer transfer)
        {
            return _mapper.Map<TransferDto>(transfer);
        }

        public List<OutgoingTransferDto> CreateTransferDtoList(List<Transfer> transfers)
        {
            return _mapper.Map<List<OutgoingTransferDto>>(transfers);
        }
        public List<IncomingTransferDto> CreateIncomingTransferDtoList(List<Transfer> transfers)
        {
            return _mapper.Map<List<IncomingTransferDto>>(transfers);
        }

        public Transfer MapToModel(OutgoingTransferDto transferDto, Transfer model)
        {
            return _mapper.Map(transferDto, model);
        }
    }
}

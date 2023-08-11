using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ITransferFactory
    {
        Transfer CreateTransfer(OutgoingTransferDto transferDto);
        OutgoingTransferDto CreateTransferDto(Transfer transfer);
        Transfer MapToModel(OutgoingTransferDto transferDto, Transfer model);
        List<OutgoingTransferDto> CreateTransferDtoList(List<Transfer> transfers);
        public List<IncomingTransferDto> CreateIncomingTransferDtoList(List<Transfer> transfers);
    }
}

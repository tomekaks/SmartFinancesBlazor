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
        Transfer CreateTransfer(CreateTransferDto createTransferDto);
        TransferDto CreateTransferDto(Transfer transfer);
        OutgoingTransferDto CreateOutgoingTransferDto(Transfer transfer);
        Transfer MapToModel(OutgoingTransferDto transferDto, Transfer model);
        List<OutgoingTransferDto> CreateOutgoingTransferDtoList(List<Transfer> transfers);
        List<TransferDto> CreateTransferDtoList(List<Transfer> transfers);
        List<IncomingTransferDto> CreateIncomingTransferDtoList(List<Transfer> transfers);
    }
}

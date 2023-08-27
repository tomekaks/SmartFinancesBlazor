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
        Transfer CreateTransfer(CreateTransferDto createTransferDto);
        TransferDto CreateTransferDto(Transfer transfer);
        List<TransferDto> CreateTransferDtoList(List<Transfer> transfers);
        Transfer MapToModel(UpdateTransferDto updateTransferDto, Transfer transfer);
    }
}

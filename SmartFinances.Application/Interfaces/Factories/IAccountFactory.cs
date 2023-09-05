using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IAccountFactory
    {
        Account CreateAccount(AccountDto accountDto);
        Account CreateFirstAccount(string userId);
        AccountDto CreateAccountDto(Account account);
        Account MapToModel(AccountDto accountDto, Account model);
        Account MapToModel(UpdateAccountDto accountDto, Account model);
    }
}

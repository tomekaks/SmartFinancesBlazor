using AutoMapper;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Application.Dto.Enums;
using SmartFinances.Core.Data;
using SmartFinances.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFinances.Application.Dto.ExpenseDtos;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.RegularExpenseDtos;
using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Application.Dto.ContactDtos;

namespace SmartFinances.Application.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>()
                .ForMember(src => src.Number, opt => opt.Ignore());
            CreateMap<Account, UpdateAccountDto>().ReverseMap();

            CreateMap<ExpenseType, ExpenseTypeDto>().ReverseMap();

            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<Expense, EditExpenseDto>().ReverseMap();

            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, UsersStatusDto>().ReverseMap();

            CreateMap<RegularExpense, RegularExpenseDto>().ReverseMap();

            CreateMap<Transfer, OutgoingTransferDto>().ReverseMap();
            CreateMap<Transfer, IncomingTransferDto>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.SenderAccountNumber, opt => opt.MapFrom(src => src.Account.Number));

            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}

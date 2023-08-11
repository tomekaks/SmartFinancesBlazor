using AutoMapper;
using SmartFinances.Core.Data;
using SmartFinances.Core.Enums;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Users.Dtos;

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

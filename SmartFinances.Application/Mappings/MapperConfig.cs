using AutoMapper;
using SmartFinances.Core.Data;
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

            CreateMap<ApplicationUser, RegisterRequest>().ReverseMap();
            CreateMap<ApplicationUser, LoginRequest>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, UsersStatusDto>().ReverseMap();

            CreateMap<RegularExpense, RegularExpenseDto>().ReverseMap();

            CreateMap<Transfer, TransferDto>().ReverseMap();
            CreateMap<CreateTransferDto, Transfer>();

            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}

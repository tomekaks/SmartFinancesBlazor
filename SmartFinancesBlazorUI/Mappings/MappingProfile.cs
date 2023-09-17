using AutoMapper;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDto, AccountVM>().ReverseMap();

            CreateMap<TransferDto, TransferVM>().ReverseMap();
            CreateMap<NewTransferVM, CreateTransferDto>();

            CreateMap<ContactDto, ContactVM>().ReverseMap();
            CreateMap<NewContactVM, ContactDto>();
            CreateMap<EditContactVM, ContactDto>();

            CreateMap<ExpenseDto, ExpenseVM>().ReverseMap();
            CreateMap<AddExpenseVM, ExpenseDto>();
            CreateMap<EditExpenseVM, EditExpenseDto>();

            CreateMap<AddRegularExpenseVM, RegularExpenseDto>();
            CreateMap<EditRegularExpenseVM, RegularExpenseDto>();
        }
    }
}

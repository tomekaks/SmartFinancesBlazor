using AutoMapper;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Models.Transfers;

namespace SmartFinancesBlazorUI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransferDto, TransferVM>().ReverseMap();
            CreateMap<NewTransferVM, TransferDto>();

            CreateMap<ContactDto, ContactVM>().ReverseMap();
            CreateMap<NewContactVM, ContactDto>();

            CreateMap<AddExpenseVM, ExpenseDto>();
            CreateMap<EditExpenseVM, ExpenseDto>();

            CreateMap<AddRegularExpenseVM, RegularExpenseDto>();
            CreateMap<EditRegularExpenseVM, RegularExpenseDto>();
        }
    }
}

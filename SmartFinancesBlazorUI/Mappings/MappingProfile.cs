﻿using AutoMapper;
using SmartFinancesBlazorUI.Models.Accounts;
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
            CreateMap<AccountDto, AccountVM>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (AccountType)src.Type));

            CreateMap<TransferDto, TransferVM>().ReverseMap();
            CreateMap<NewTransferVM, CreateTransferDto>();

            CreateMap<ContactDto, ContactVM>().ReverseMap();
            CreateMap<NewContactVM, ContactDto>();
            CreateMap<EditContactVM, ContactDto>();

            CreateMap<ExpenseDto, ExpenseVM>()
                .ForMember(dest => dest.ExpenseTypeVM, opt => opt.MapFrom(src => src.ExpenseTypeDto)).ReverseMap();
            CreateMap<ExpenseDto, EditExpenseVM>().ReverseMap();
            CreateMap<AddExpenseVM, ExpenseDto>();
            CreateMap<AddExpenseVM, RegularExpenseDto>();
            CreateMap<EditExpenseVM, EditExpenseDto>();

            CreateMap<RegularExpenseDto, RegularExpenseVM>()
                .ForMember(dest => dest.ExpenseTypeVM, opt => opt.MapFrom(src => src.ExpenseTypeDto)).ReverseMap();
            CreateMap<AddRegularExpenseVM, RegularExpenseDto>();
            CreateMap<EditRegularExpenseVM, EditRegularExpenseDto>();
            CreateMap<RegularExpenseVM, EditRegularExpenseDto>()
                .ForMember(dest => dest.ExpenseTypeId, opt => opt.MapFrom(src => src.ExpenseTypeVM.Id));

            CreateMap<ExpenseTypeDto, ExpenseTypeVM>().ReverseMap();

            CreateMap<YearlySummaryDto, YearlySummaryVM>().ReverseMap();

            CreateMap<MonthlySummaryDto, MonthlySummaryVM>().ReverseMap();
        }
    }
}

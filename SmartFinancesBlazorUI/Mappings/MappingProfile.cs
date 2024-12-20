﻿using AutoMapper;
using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Admin;
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
            CreateMap<TransferDto, TransferVM>()
                .ForMember(dest => dest.SendTime, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.SendTime)))
                .ReverseMap();
            CreateMap<NewTransferVM, CreateTransferDto>();

            CreateMap<ContactDto, ContactVM>().ReverseMap();
            CreateMap<NewContactVM, ContactDto>();

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

            CreateMap<TransactionalAccountDto, TransactionalAccountVM>()
                .ForMember(dest => dest.AccountTypeVM, opt => opt.MapFrom(src => src.AccountTypeDto));

            CreateMap<SavingsAccountDto, SavingsAccountVM>()
                .ForMember(dest => dest.AccountTypeVM, opt => opt.MapFrom(src => src.AccountTypeDto));

            CreateMap<AccountRequestDto, AccountRequestVM>()
                .ForMember(dest => dest.AccountTypeVM, opt => opt.MapFrom(src => src.AccountTypeDto))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserDto.UserName));

            CreateMap<AccountTypeDto, AccountTypeVM>();
        }
    }
}

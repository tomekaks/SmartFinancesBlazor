﻿using AutoMapper;
using SmartFinances.Core.Data;
using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Users.Dtos;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Application.Features.YearlySummaries.Dtos;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            CreateMap<ExpenseType, ExpenseTypeDto>().ReverseMap();
            CreateMap<EditExpenseTypeDto, ExpenseType>();

            CreateMap<Expense, ExpenseDto>()
                .ForMember(dest => dest.ExpenseTypeDto, opt => opt.MapFrom(src => src.ExpenseType));
            CreateMap<ExpenseDto, Expense>();
            CreateMap<Expense, EditExpenseDto>().ReverseMap();

            CreateMap<ApplicationUser, RegisterRequest>().ReverseMap();
            CreateMap<ApplicationUser, LoginRequest>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, UsersStatusDto>().ReverseMap();

            CreateMap<RegularExpense, RegularExpenseDto>()
                .ForMember(dest => dest.ExpenseTypeDto, opt => opt.MapFrom(src => src.ExpenseType));
            CreateMap<RegularExpenseDto, RegularExpense>();
            CreateMap<EditRegularExpenseDto, RegularExpense>();

            CreateMap<Transfer, TransferDto>().ReverseMap();
            CreateMap<CreateTransferDto, Transfer>();

            CreateMap<Contact, ContactDto>().ReverseMap();

            CreateMap<YearlySummary, YearlySummaryDto>().ReverseMap();
            CreateMap<UpdateYearlySummaryDto, YearlySummary>();
            CreateMap<CreateYearlySummaryDto, YearlySummary>();

            CreateMap<MonthlySummary, MonthlySummaryDto>().ReverseMap();
            CreateMap<CreateMonthlySummaryDto, MonthlySummary>();
            CreateMap<UpdateMonthlySummaryDto, MonthlySummary>();

            CreateMap<SavingsAccount, SavingsAccountDto>().ReverseMap();
            CreateMap<CreateSavingsAccountDto, SavingsAccount>();
            CreateMap<UpdateSavingsAccountDto, SavingsAccount>();

            CreateMap<TransactionalAccount, TransactionalAccountDto>().ReverseMap();
            CreateMap<CreateTransactionalAccountDto, TransactionalAccount>();
            CreateMap<UpdateTransactionalAccountDto, TransactionalAccount>();
        }
    }
}

﻿using AutoMapper;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Models.Transfers;

namespace SmartFinancesBlazorUI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransferDto, TransferVM>().ReverseMap();

            CreateMap<ContactDto, ContactVM>().ReverseMap();
        }
    }
}

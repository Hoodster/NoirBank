using System;
using AutoMapper;

namespace NoirBank
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.DTO.Address, Data.Entities.Address>();
            CreateMap<Data.DTO.AccountDTO, Data.Entities.Customer>();
        }
    }
}


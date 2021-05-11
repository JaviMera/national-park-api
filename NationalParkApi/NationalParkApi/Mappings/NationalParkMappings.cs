using System;
using AutoMapper;
using NationalParkApi.Models;
using NationalParkApi.Models.Dtos;

namespace NationalParkApi.Mappings
{
    public class NationalParkMappings : Profile
    {
        public NationalParkMappings()
        {
            CreateMap<NationalParkDto, NationalPark>().ReverseMap();
        }
    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();       
        }
    }
}

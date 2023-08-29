using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public class WalksProfile :Profile
    {
        public WalksProfile()
        {
            CreateMap<NZWalks.API.Models.DTO.WalkDto, NZWalks.API.Models.Domain.Walk>().
                ReverseMap();

            CreateMap<NZWalks.API.Models.Domain.WalkDifficulty, NZWalks.API.Models.Domain.WalkDifficulty>()
                .ReverseMap();

            CreateMap<Region, Region>().
                ReverseMap();
        }
    }
}

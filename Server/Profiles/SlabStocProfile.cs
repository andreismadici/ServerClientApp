using AutoMapper;
using ServerMagazin.Dtos;
using ServerMagazin.Models;

namespace ServerMagazin.Profiles
{
    public class SlabStocProfile : Profile
    {
        public SlabStocProfile()
        {
            //Source -> Target
            CreateMap<SlabStoc, SlabStocReadDto>();
            CreateMap<SlabStocCreateDto, SlabStoc>();
            
        }
    }
}
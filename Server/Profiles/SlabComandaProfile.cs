using AutoMapper;
using ServerMagazin.Dtos;
using ServerMagazin.Models;

namespace ServerMagazin.Profiles
{
    public class SlabComandaProfile : Profile
    {
        public SlabComandaProfile()
        {
            //Source -> Target
            CreateMap<SlabComanda, SlabComandaReadDto>();
            CreateMap<SlabComandaCreateDto, SlabComanda>();
            
        }
    }
}
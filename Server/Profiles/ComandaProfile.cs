using AutoMapper;
using ServerMagazin.Dtos;
using ServerMagazin.Models;

namespace ServerMagazin.Profiles
{
    public class ComandaProfile : Profile
    {
        public ComandaProfile()
        {
            //Source -> Target
            CreateMap<Comanda, ComandaReadDto>();
            CreateMap<ComandaCreateDto, Comanda>();
            //CreateMap<ClientUpdateDto, Client>();
            //CreateMap<Client, ClientUpdateDto>();
            //CreateMap<ClientLoginDto, Client>();
        }
    }
}
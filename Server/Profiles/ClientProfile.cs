using AutoMapper;
using ServerMagazin.Dtos;
using ServerMagazin.Models;

namespace ServerMagazin.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            //Source -> Target
            CreateMap<Client, ClientReadDto>();
            CreateMap<ClientCreateDto, Client>();
            CreateMap<ClientUpdateDto, Client>();
            CreateMap<Client, ClientUpdateDto>();
            CreateMap<ClientLoginDto, Client>();
        }
    }
}
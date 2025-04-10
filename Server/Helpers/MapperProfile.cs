using AutoMapper;
using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Models;

namespace CarMember_server.Helpers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
        // et vice versa grace au .ReverseMap()
        CreateMap<User, UserProfilRequestDTO>().ReverseMap();
        CreateMap<User , UserProfilResponseDTO>().ReverseMap();

    }
}

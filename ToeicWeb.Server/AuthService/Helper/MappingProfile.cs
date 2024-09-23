using AutoMapper;
using ToeicWeb.Server.AuthService.Dto;
using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}

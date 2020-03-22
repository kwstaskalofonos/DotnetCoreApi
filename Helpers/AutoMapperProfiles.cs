using AutoMapper;
using customserver.Helpers;
using CustomServer.Dtos;
using CustomServer.Models;

namespace CustomServer.Helpers
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UsersListDto>();
            CreateMap<Models.Profile, ProfilesListDto>()
                .ForMember(dest =>dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo,PhotoListDto>();
        }
        
    }
}
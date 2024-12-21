namespace the_memory_game_asp_dotnet_core.Mappings;

using AutoMapper;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Entities;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        // Map Create Request to User
        CreateMap<UserRequest.Create, User>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        
        // Map User to Get Response
        CreateMap<User, UserResponse.Get>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.IsPaidUser, opt => opt.MapFrom(src => src.IsPaidUser));
    }
}

namespace the_memory_game_asp_dotnet_core.Mappings;

using AutoMapper;

using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Entities;

public class ScoreMappingProfile : Profile
{
    public ScoreMappingProfile()
    {
        // Map from ScoreRequest.Create to Score entity
        CreateMap<ScoreRequest.Create, Score>()
            .ForMember(dest => dest.ScoreId, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Points, opt => opt.Ignore());

        // Map from Score entity to ScoreResponse.Create
        CreateMap<Score, ScoreResponse.Create>();

        // Map from Score entity to ScoreResponse.Get
        CreateMap<Score, ScoreResponse.Get>();
    }
}

using AutoMapper;
using Patrick_WebAPI.Models.Domain;
using Patrick_WebAPI.Models.DTO;

namespace Patrick_WebAPI.Mappings
{
	public class AutoMapperProfiles :Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<RegionDto, Region>().ReverseMap();
			CreateMap<AddRegionRequestDto,Region>().ReverseMap();
			CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();
			CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
			CreateMap<Walk, WalkDto>().ReverseMap();
			CreateMap<Difficulty, DifficultyDto>().ReverseMap();
			CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
		} 
	}
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patrick_WebAPI.CustomActionFilters;
using Patrick_WebAPI.Data;
using Patrick_WebAPI.Models.Domain;
using Patrick_WebAPI.Models.DTO;
using Patrick_WebAPI.Repositories;
using System.Collections.Generic;

namespace Patrick_WebAPI.Controllers
{

	// localhost:port/api/Regions

	[Route("api/[controller]")]
	
	[ApiController]
	public class RegionsController : ControllerBase
	{
 
		private readonly NZWalksDbContext dbContext;
		private readonly IRegionRepository regionRepository;
		private readonly IMapper mapper;
		public RegionsController(NZWalksDbContext dbContext , IRegionRepository regionRepository,
			IMapper mapper )
		{
			this.dbContext = dbContext;
			this.regionRepository = regionRepository;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
		   var regionsDomain = await regionRepository.GetAllAsync();

			// mapping Domain Model to DTO
			//var regionsDto = new List<RegionDto>();
			//foreach (var regionDomain in regionsDomain)
			//{
			//	regionsDto.Add(new RegionDto()
			//	{
			//		Id = regionDomain.Id,
			//		Name = regionDomain.Name,
			//		Code = regionDomain.Code,
			//		RegionImageUrl = regionDomain.RegionImageUrl
			//	}
			//	);
			//}

			var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

			return Ok(regionsDto);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetOnly([FromRoute] Guid id) {

			// Getting Region Domain Model From Database

			var regionDomain = await regionRepository.GetOnlyAsync(id);
			if (regionDomain == null)
			{
				return NotFound();
				}
			//Mapping Region Domain Model to Region DTO
			//RegionDto regionDto = new RegionDto()
			//{
			//	Id = regionDomain.Id, 
			//	Name = regionDomain.Name,
			//	Code = regionDomain.Code,
			//	RegionImageUrl = regionDomain.RegionImageUrl
			//};
			// -- Mapper.Map<Destination>(Source);
			var regionDto =mapper.Map<RegionDto>(regionDomain);

			return Ok(regionDto);

		}

		[HttpPost]
		[ValidateModel]
		public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto) {
 
				//Map or convert DTO to Domain Model
				// use domain model to create Region
				//Region regionDomainModel = new Region()
				//{
				//	Code = addRegionRequestDto.Code,
				//	Name = addRegionRequestDto.Name, 
				//	RegionImageUrl = addRegionRequestDto.RegionImageUrl
				//};
				var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
				regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

				// Map Domain Model to Dto
				//RegionDto regionDto = new RegionDto()
				//{
				//	Id = regionDomainModel.Id,
				//	Name = regionDomainModel.Name,
				//	Code = regionDomainModel.Code,
				//	RegionImageUrl = regionDomainModel.RegionImageUrl
				//};
				var regionDto = mapper.Map<RegionDto>(regionDomainModel);
				return CreatedAtAction(nameof(GetOnly), new { id = regionDomainModel.Id }, regionDto);
				//return Ok(regionDomainModel);
			 
		}

		[HttpPut]
		[Route("{id:Guid}")]
		[ValidateModel]
		public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody]   UpdateRegionRequestDto updateRegionRequestDto)
		{
			 // Map DTO to Domain Model
			//var regiondomainModel = new Region()
			//{
			//	Code = updateRegionRequestDto.Code,
			//	Name = updateRegionRequestDto.Name,
			//	RegionImageUrl = updateRegionRequestDto.RegionImageUrl
			//};
			var regiondomainModel = mapper.Map<Region>(updateRegionRequestDto);
			var regionDomainModel = await regionRepository.UpdateAsync(id, regiondomainModel);
			
				if(regionDomainModel == null)
				{
					return NotFound();
				}
			 
			// converting Domain Model to DTO

			//RegionDto regionDto = new RegionDto()
			//{
			//	Id = regionDomainModel.Id,
			//	Name = regionDomainModel.Name,
			//	Code = regionDomainModel.Code,
			//	RegionImageUrl = regionDomainModel.RegionImageUrl
			//};

			var regionDto = mapper.Map<RegionDto>(regionDomainModel);
			return Ok(regionDto);
		}


		[HttpDelete]
		[Route("id:Guid")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var regionDomainModel = await regionRepository.DeleteAsync(id);
			if (regionDomainModel == null)
			{
				return NotFound();
			}
			// map domain model to DTO 

			//RegionDto regionDto = new RegionDto()
			//{
			//	Id = regionDomainModel.Id,
			//	Name = regionDomainModel.Name,
			//	Code = regionDomainModel.Code,
			//	RegionImageUrl = regionDomainModel.RegionImageUrl 
			//};

			var regionDto = mapper.Map<RegionDto>(regionDomainModel);
			return Ok(regionDto);
		}


	}
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Patrick_WebAPI.Data;
using Patrick_WebAPI.Models.Domain;
using Patrick_WebAPI.Repositories;

namespace Patrick_WebAPI.Repositories
{
	public class SQLRegionRepository : IRegionRepository
	{
		private readonly NZWalksDbContext dbContext;
		public SQLRegionRepository(NZWalksDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<List<Region>> GetAllAsync()
		{
				return await dbContext.Regions.ToListAsync();
		}

		public async Task<Region?> GetOnlyAsync(Guid id)
		{
			return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id==id);
		}

		public async Task<Region> CreateAsync(Region region )
		{
			await dbContext.Regions.AddAsync(region);
			await dbContext.SaveChangesAsync();
			return region;
		}

		 

		async Task<Region?> IRegionRepository.UpdateAsync(Guid id, Region region)
		{
			 var exitingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id==id);
			if (exitingRegion == null)
			{
				return null;
			}	
			exitingRegion.Code = region.Code;
			exitingRegion.Name = region.Name;
			exitingRegion.RegionImageUrl = region.RegionImageUrl;

			await dbContext.SaveChangesAsync();
			return exitingRegion;
		}

		public async Task<Region?> DeleteAsync(Guid id)
		{
			 var existingRegion = await  dbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
			if (existingRegion == null)
			{
				return null;
			}
			 dbContext.Regions.Remove(existingRegion);
			await  dbContext.SaveChangesAsync();
			return existingRegion;
		}
	}
}

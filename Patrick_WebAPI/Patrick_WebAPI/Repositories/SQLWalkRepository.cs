﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Patrick_WebAPI.Data;
using Patrick_WebAPI.Models.Domain;
using System.Data.Entity;


namespace Patrick_WebAPI.Repositories
{
	public class SQLWalkRepository : IWalkRepository
	{
		private readonly NZWalksDbContext dbContext;

		public SQLWalkRepository( NZWalksDbContext dbContext)
		{
			 this.dbContext = dbContext;
		}
		public async Task<Walk> CreateAsync(Walk walk)
		{
			await dbContext.Walks.AddAsync(walk);
			await dbContext.SaveChangesAsync();
			return walk;
		}

		public async Task<Walk?> DeleteAsync(Guid id)
		{
			 var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x =>x.ID== id);
			if(existingWalk == null)
			{
				return null;
			}
			 dbContext.Walks.Remove( existingWalk);
			await dbContext.SaveChangesAsync();
			return existingWalk;
		}

		public async Task<List<Walk>> GetAllAsync(string? FilterOn = null, string? FilterQuery = null)
		{

			// var walks = await dbcontext.walks.Include("Difficulty").Include("region").asqueryable();

			 
			//if (string.IsNullOrWhiteSpace(FilterOn) == false  && string.IsNullOrWhiteSpace(FilterQuery)==false)
			//{
			//	if(FilterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
			//	{
			//		walks = walks.Where(x => x.Name.Contains(FilterQuery));
			//	}
			//}
			// return await walks.ToListAsync();
			return await dbContext.Walks.ToListAsync();
		}

		public async Task<Walk?> GetByIdAsync(Guid id)
		{
			 
			return await dbContext.Walks.FirstOrDefaultAsync(x=> x.ID == id);
		}

		public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
		{
			 var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x=>x.ID == id);
			if (existingWalk == null) {
				return null;
			}
			existingWalk.Name=walk.Name;
			existingWalk.Description=walk.Description;
			existingWalk.LengthInKm = walk.LengthInKm;
			existingWalk.WalkImageUrl=walk.WalkImageUrl;
			existingWalk.DifficultyId=walk.DifficultyId;
			existingWalk.RegionId=walk.RegionId;

			await dbContext.SaveChangesAsync();
			return  existingWalk;
		}
	} 
}

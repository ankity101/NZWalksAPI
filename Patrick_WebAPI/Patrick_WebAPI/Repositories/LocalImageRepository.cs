﻿using Patrick_WebAPI.Data;
using Patrick_WebAPI.Models.Domain;

namespace Patrick_WebAPI.Repositories
{
	public class LocalImageRepository : IImageRepository
	{
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly NZWalksDbContext dbContext;

		public LocalImageRepository(IWebHostEnvironment webHostEnvironment , IHttpContextAccessor httpContextAccessor , NZWalksDbContext dbContext)
		{
			this.webHostEnvironment = webHostEnvironment;
			this.httpContextAccessor = httpContextAccessor;
			this.dbContext = dbContext;
		}  
		public async Task<Image> Upload(Image image)
		{
			var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");


			//Upload Image to local Path


			using var stream = new FileStream(localFilePath, FileMode.Create);

			await image.File.CopyToAsync(stream);

			// I will get the file path in terms of  localhost:port/....

			
			var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
			image.FilePath = urlFilePath;

			// Save Image into Database

			await dbContext.Images.AddAsync(image);
			await dbContext.SaveChangesAsync();

			return image;
		}
	}
}

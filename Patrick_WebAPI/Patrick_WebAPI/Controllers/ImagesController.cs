using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patrick_WebAPI.Models.Domain;
using Patrick_WebAPI.Models.DTO;
using Patrick_WebAPI.Repositories;

namespace Patrick_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IImageRepository imageRepository;

		public ImagesController(IImageRepository imageRepository)
		{
			this.imageRepository = imageRepository;
		}

		// /api/Images/Update
		[HttpPost]
		public async Task<IActionResult> Update([FromForm] ImageUploadRequestDto imageUploadRequestDto)
		{

			ValidateRequest(imageUploadRequestDto);

			if(ModelState.IsValid)
			{
				//Conver Dto to Domain Model

				var imageDomainModel = new Image
				{
					File = imageUploadRequestDto.File,
					FileExtension = Path.GetExtension(imageUploadRequestDto.File.FileName),
					FileSizeInBytes = imageUploadRequestDto.File.Length,
					FileName = imageUploadRequestDto.File.FileName,
					FileDescription = imageUploadRequestDto.FileDescription
				};

				//User Repository to upload image

				await imageRepository.Upload(imageDomainModel);

				return Ok(imageDomainModel);
			}

			return BadRequest(ModelState);
		}



		private void ValidateRequest(ImageUploadRequestDto request)
		{
			var allowedExtension = new string[] { ".jpg", ".png", ".jpeg" };

			if(allowedExtension.Contains(Path.GetExtension(request.File.FileName))== false)
			{
				ModelState.AddModelError("File", "Unsupported file extension");
			}
			if (request.File.Length > 10485760)
				ModelState.AddModelError("file", "File Size is more than 10MB please Upload a smaller sime file!");


		}
	}
}

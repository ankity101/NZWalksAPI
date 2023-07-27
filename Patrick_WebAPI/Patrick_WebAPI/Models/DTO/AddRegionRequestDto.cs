using System.ComponentModel.DataAnnotations;

namespace Patrick_WebAPI.Models.DTO
{
	public class AddRegionRequestDto
	{

		[Required]
		[MinLength(3 , ErrorMessage=" Code Length sould be min 3 length")]
		[MaxLength(3,ErrorMessage ="Code Length can not exceed 3 charecter")]
		public string Code { get; set; }

		[Required]
		[MaxLength(100,ErrorMessage ="Name Length can not exceed 100 charecter")]
		public string Name { get; set; }
		public string? RegionImageUrl { get; set; }

	}
}

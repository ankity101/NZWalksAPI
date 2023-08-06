using Patrick_WebAPI.Models.Domain;

namespace Patrick_WebAPI.Repositories
{
	public interface IImageRepository 
	{
		 
		Task<Image> Upload(Image image);
	}
}

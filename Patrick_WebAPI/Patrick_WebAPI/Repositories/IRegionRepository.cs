using Patrick_WebAPI.Models.Domain;
using Patrick_WebAPI.Models.DTO;

namespace Patrick_WebAPI.Repositories
{
	public interface IRegionRepository
	{
		Task<List<Region>> GetAllAsync();
		Task<Region?> GetOnlyAsync(Guid id);
		Task<Region> CreateAsync(Region region);

		Task<Region?> UpdateAsync(Guid id, Region region);

		Task<Region?> DeleteAsync(Guid id);
	}
}

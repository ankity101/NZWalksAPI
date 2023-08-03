using Microsoft.AspNetCore.Identity;

namespace Patrick_WebAPI.Repositories
{
	public interface ITokenRepository
	{
		string CreateJWTToken(IdentityUser user , List<string> roles);

	}
}

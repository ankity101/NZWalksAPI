using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Patrick_WebAPI.Models.DTO;
using Patrick_WebAPI.Repositories;

namespace Patrick_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly ITokenRepository tokenRepository;
		public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
		{
				this.tokenRepository= tokenRepository;
				this.userManager = userManager;
		}
		//POST: /api/Auth/Register
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
		{
			var identityUser = new IdentityUser
			{
				UserName = registerRequestDto.Username,
				Email = registerRequestDto.Username
			};

		 var identityResult = 	await userManager.CreateAsync(identityUser, registerRequestDto.Password);

			if(identityResult.Succeeded)
			{
				// Add roles to User
				if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
				{
					identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
					
					if(identityResult.Succeeded)   
					{
						return Ok("User Is registered ! Go ahed and login.");
					}
				}
					
			}
			return BadRequest("Something went wrong");
		}

		//POST : /API/Auth/Login
		[HttpPost]
		[Route("Login")]

		public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
		{
			var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
			if (user != null) 
			{
				var cheakPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
				if (cheakPasswordResult)
				{

					// roles of user

					var roles = await userManager.GetRolesAsync(user);

					if (roles != null)
					{
						//Create  A Token

						var JwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

						var response = new LoginResposeDto
						{
							JwtToken = JwtToken
						};
						return Ok(response);
					}

				}
			}
			return BadRequest("Username or Password is Incorrect");
			
		}
	}
}

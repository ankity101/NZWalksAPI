
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Patrick_WebAPI.Data
{
	public class NZWalksAuthDbContext : IdentityDbContext 
	{
		public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
		{

		}  

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var readerRoleId = "b8811e41-8fe9-40e3-836d-bf8aa20e52d9";
			var writerRoleId = "49fed64c-484a-4356-afac-551d7e9dd523";

			var roles = new List<IdentityRole>
			{
				new IdentityRole()
				{
					Id=readerRoleId,
					ConcurrencyStamp =readerRoleId,
					Name = "Reader",
					NormalizedName = "Reader".ToUpper()
				},
				new IdentityRole()
				{
					Id=writerRoleId,
					ConcurrencyStamp =writerRoleId,
					Name = "Writer",
					NormalizedName = "Writer".ToUpper()
				}
			};

			builder.Entity<IdentityRole>().HasData(roles);
		}
	}
}

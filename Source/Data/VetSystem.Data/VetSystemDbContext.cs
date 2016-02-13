namespace VetSystem.Data
{
	using Microsoft.AspNet.Identity.EntityFramework;

	using VetSystem.Data.Models;

	public class VetSystemDbContext : IdentityDbContext<User>
	{
		public VetSystemDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static VetSystemDbContext Create()
		{
			return new VetSystemDbContext();
		}
	}
}

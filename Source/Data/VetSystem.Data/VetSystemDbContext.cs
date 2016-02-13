namespace VetSystem.Data
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	using Microsoft.AspNet.Identity.EntityFramework;

	using VetSystem.Data.Common.Models;
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

		public override int SaveChanges()
		{
			this.ApplyAuditInfoRules();
			return base.SaveChanges();
		}

		private void ApplyAuditInfoRules()
		{
			// Approach via @julielerman: http://bit.ly/123661P
			foreach (var entry in
				this.ChangeTracker.Entries()
					.Where(
						e =>
						e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
			{
				var entity = (IAuditInfo)entry.Entity;
				if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
				{
					entity.CreatedOn = DateTime.Now;
				}
				else
				{
					entity.ModifiedOn = DateTime.Now;
				}
			}
		}
	}
}

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

		public virtual IDbSet<Clinic> Clinics { get; set; }

		public virtual IDbSet<Pet> Pets { get; set; }

		public virtual IDbSet<PetSpecies> Species { get; set; }

		public static VetSystemDbContext Create()
        {
            return new VetSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
			try
			{
				return base.SaveChanges();

			}
			catch (Exception ex)
			{
				var a = (ex as System.Data.Entity.Validation.DbEntityValidationException)
  .EntityValidationErrors
  .ToList()[0]
  .ValidationErrors
  .ToList()[0];
				throw;
			}
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasMany(u => u.Pets).WithRequired(p => p.Owner).WillCascadeOnDelete(true);
			modelBuilder.Entity<User>().HasMany(u => u.Companies).WithRequired(c => c.Owner).WillCascadeOnDelete(true);
			modelBuilder.Entity<Clinic>().HasMany(c => c.Pets).WithRequired(p => p.Clinic).WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
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

namespace VetSystem.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common.Models;
    using System;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
		private ICollection<Pet> pets;
		private ICollection<Clinic> companies;
        private ICollection<Rating> ratings;

        public User()
		{
            this.CreatedOn = DateTime.UtcNow;

            this.pets = new HashSet<Pet>();
			this.companies = new HashSet<Clinic>();
			this.ratings = new HashSet<Rating>();
        }

        public virtual ICollection<Pet> Pets
		{
			get { return this.pets; }
			set { this.pets = value; }
		}

		public virtual ICollection<Clinic> Companies
		{
			get { return this.companies; }
			set { this.companies = value; }
		}

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}

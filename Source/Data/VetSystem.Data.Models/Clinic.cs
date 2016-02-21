namespace VetSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VetSystem.Common.Constants;
    using VetSystem.Data.Common.Models;

    public class Clinic : BaseModel<int>
	{
		private ICollection<Pet> pets;
		private ICollection<Rating> ratings;

		public Clinic()
		{
			this.pets = new HashSet<Pet>();
			this.ratings = new HashSet<Rating>();
		}

		[Required]
        [MinLength(ValidationConstants.MinClinicNameLength)]
        [MaxLength(ValidationConstants.MaxClinicNameLength)]
		public string Name { get; set; }

		[Required]
        [MinLength(ValidationConstants.MinClinicInformationLength)]
        [MaxLength(ValidationConstants.MaxClinicInformationLength)]
		public string Information { get; set; }

		public string OwnerId { get; set; }

		public virtual User Owner { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Pet> Pets
		{
			get { return this.pets; }
			set { this.pets = value; }
		}

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
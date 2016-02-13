namespace VetSystem.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using VetSystem.Data.Common.Models;

	public class Clinic : BaseModel<int>
	{
		private ICollection<Pet> pets;

		public Clinic()
		{
			this.pets = new HashSet<Pet>();
		}

		[Required]
		public string Name { get; set; }

		[Required]
		public string Information { get; set; }

		public string OwnerId { get; set; }

		public virtual User Owner { get; set; }

		public virtual ICollection<Pet> Pets
		{
			get { return this.pets; }
			set { this.pets = value; }
		}
	}
}
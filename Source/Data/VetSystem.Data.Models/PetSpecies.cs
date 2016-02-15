namespace VetSystem.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	using VetSystem.Data.Common.Models;

	public class PetSpecies : BaseModel<int>
	{
		private ICollection<Pet> pets;

		public PetSpecies()
		{
			this.pets = new HashSet<Pet>();
		}

		[Required]
		[MinLength(1)]
		[MaxLength(100)]
		public string Name { get; set; }

		public ICollection<Pet> Pets
		{
			get { return this.pets; }
			set { this.pets = value; }
		}
	}
}

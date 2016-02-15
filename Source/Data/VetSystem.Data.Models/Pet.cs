namespace VetSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using VetSystem.Data.Common.Models;

	public class Pet : BaseModel<int>
	{
		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[Range(0, 1000)]
		public int Age { get; set; }

		public PetGender Gender { get; set; }

		public double Weight { get; set; }

		public int SpeciesId { get; set; }

		public virtual PetSpecies Species { get; set; }

		public string OwnerId { get; set; }

		public virtual User Owner { get; set; }

		public int? ClinicId { get; set; }

		public virtual Clinic Clinic { get; set; }
	}
}

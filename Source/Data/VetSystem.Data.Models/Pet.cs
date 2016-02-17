namespace VetSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using VetSystem.Common.Constants;
    using VetSystem.Data.Common.Models;

    public class Pet : BaseModel<int>
	{
		[Required]
		[MinLength(ValidationConstants.MinPetNameLength)]
		[MaxLength(ValidationConstants.MaxPetNameLength)]
		public string Name { get; set; }

		[Required]
		[Range(ValidationConstants.MinPetAgeValue, ValidationConstants.MaxPetAgeValue)]
		public int Age { get; set; }

		public PetGender Gender { get; set; }

        [Range(ValidationConstants.MinPetWeightValue, ValidationConstants.MaxPetWeightValue)]
		public double Weight { get; set; }

		public int SpeciesId { get; set; }

		public virtual PetSpecies Species { get; set; }

		public string OwnerId { get; set; }

		public virtual User Owner { get; set; }

		public int? ClinicId { get; set; }

		public virtual Clinic Clinic { get; set; }

        public virtual Image Image { get; set; }
    }
}

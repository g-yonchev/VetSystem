namespace VetSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VetSystem.Common.Constants;
    using VetSystem.Data.Common.Models;

    public class PetSpecies : BaseModel<int>
    {
        private ICollection<Pet> pets;

        public PetSpecies()
        {
            this.pets = new HashSet<Pet>();
        }

        [Required]
        [MinLength(ValidationConstants.MinPetSpeciesNameLength)]
        [MaxLength(ValidationConstants.MaxPetSpeciesNameLength)]
        public string Name { get; set; }

        public ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }
    }
}

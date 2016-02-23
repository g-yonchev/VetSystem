namespace VetSystem.Web.Areas.Pets.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    using VetSystem.Common.Constants;
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class PetCreateViewModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinPetNameLength)]
        [MaxLength(ValidationConstants.MaxPetNameLength)]
        public string Name { get; set; }

        [Required]
        [Range(ValidationConstants.MinPetAgeValue, ValidationConstants.MaxPetAgeValue)]
        public int Age { get; set; }

        [Required]
        [Display(Name = "What is your pet?")]
        public int SpeciesId { get; set; }

        public PetGender Gender { get; set; }

        public string Picture { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
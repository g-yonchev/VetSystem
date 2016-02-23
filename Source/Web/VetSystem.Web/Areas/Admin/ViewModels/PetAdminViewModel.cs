namespace VetSystem.Web.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using VetSystem.Common.Constants;
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;
    using VetSystem.Web.Areas.Pets.ViewModels;

    public class PetAdminViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinPetNameLength)]
        [MaxLength(ValidationConstants.MaxPetNameLength)]
        public string Name { get; set; }

        [Required]
        [Range(ValidationConstants.MinPetAgeValue, ValidationConstants.MaxPetAgeValue)]
        public int Age { get; set; }

        public string Gender { get; set; }

        public SpeciesViewModel Species { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }

        [Display(Name = "Clinic")]
        public string ClinicName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Pet, PetAdminViewModel>()
                .ForMember(x => x.ClinicName, opts => opts.MapFrom(x => x.Clinic == null ? "N/A" : x.Clinic.Name))
                .ForMember(x => x.Gender, opts => opts.MapFrom(x => x.Gender.ToString()))
                .ForMember(x => x.OwnerName, opts => opts.MapFrom(x => x.Owner.UserName));
        }
    }
}
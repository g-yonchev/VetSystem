using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using VetSystem.Common.Constants;
using VetSystem.Data.Models;
using VetSystem.Web.Infrastructure.Mapping;

namespace VetSystem.Web.Areas.Pets.ViewModels
{
    public class PetCreateViewModel : IMapFrom<Pet>, IHaveCustomMappings
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
        [MinLength(ValidationConstants.MinPetSpeciesNameLength)]
        [MaxLength(ValidationConstants.MaxPetSpeciesNameLength)]
        public string Species { get; set; }

        public PetGender Gender { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Pet, PetCreateViewModel>()
                .ForMember(x => x.Species, opts => opts.MapFrom(x => x.Species.Name));
        }
    }
}
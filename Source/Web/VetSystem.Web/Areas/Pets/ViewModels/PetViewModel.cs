namespace VetSystem.Web.Areas.Pets.ViewModels
{
    using AutoMapper;
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class PetViewModel : IMapFrom<Pet>, IHaveCustomMappings
	{
		public int Id { get; set; }

        public string Name { get; set; }
        
		public string ClinicName { get; set; }

        public string Species { get; set; }

        public int Age { get; set; }

        public string Picture { get; set; }

		public void CreateMappings(IMapperConfiguration configuration)
		{
            configuration.CreateMap<Pet, PetViewModel>()
                .ForMember(m => m.Species, opts => opts.MapFrom(p => p.Species.Name.ToLower()))
                .ForMember(m => m.ClinicName, opts => opts.MapFrom(p => p.Clinic == null ? "None clinic yet" : p.Clinic.Name));
		}
	}
}
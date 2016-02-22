namespace VetSystem.Web.Areas.Pets.ViewModels
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;
    
    public class PetViewModel : IMapFrom<Pet>, IHaveCustomMappings
	{
		public int Id { get; set; }

        [UIHint("Name")]
        public string Name { get; set; }
        
        [UIHint("Clinic")]
        public string ClinicName { get; set; }

        [UIHint("Species")]
        public string Species { get; set; }

        [UIHint("Age")]
        public int Age { get; set; }

        [UIHint("Picture")]
        public string Picture { get; set; }

		public void CreateMappings(IMapperConfiguration configuration)
		{
            configuration.CreateMap<Pet, PetViewModel>()
                .ForMember(m => m.Species, opts => opts.MapFrom(p => p.Species.Name.ToLower()))
                .ForMember(m => m.ClinicName, opts => opts.MapFrom(p => p.Clinic == null ? "None clinic yet" : p.Clinic.Name));
		}
	}
}
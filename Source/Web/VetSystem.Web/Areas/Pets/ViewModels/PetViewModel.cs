namespace VetSystem.Web.Areas.Pets.ViewModels
{
	using AutoMapper;

	using VetSystem.Data.Models;
	using VetSystem.Web.Infrastructure.Mapping;

	public class PetViewModel : IMapFrom<Pet>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ClinicName { get; set; }

		public void CreateMappings(IMapperConfiguration configuration)
		{
			configuration.CreateMap<Pet, PetViewModel>()
				.ForMember(m => m.ClinicName, opts => opts.MapFrom(p => p.Clinic.Name));
		}
	}
}
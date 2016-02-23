namespace VetSystem.Web.ViewModels.Clinics
{
    using System.Linq;

    using AutoMapper;

    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class ClinicSimpleToPetCountViewModel : IMapFrom<Clinic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PetsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Clinic, ClinicSimpleToPetCountViewModel>()
               .ForMember(m => m.PetsCount, opt => opt.MapFrom(x => x.Pets.Any() ? x.Pets.Count() : 0));
        }
    }
}
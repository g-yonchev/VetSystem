namespace VetSystem.Web.ViewModels.Clinics
{
    using System.Linq;

    using AutoMapper;

    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class ClinicSimpleRatedViewModel : IMapFrom<Clinic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Clinic, ClinicSimpleRatedViewModel>()
               .ForMember(m => m.Rating, opt => opt.MapFrom(x => x.Ratings.Any() ? x.Ratings.Average(r => r.Value) : 0));
        }
    }
}
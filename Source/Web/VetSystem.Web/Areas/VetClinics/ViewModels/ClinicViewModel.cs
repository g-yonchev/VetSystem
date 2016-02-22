namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    using System.Linq;

    using AutoMapper;

    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;
    using Services.Web;
    public class ClinicViewModel : IMapFrom<Clinic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/VetClinics/Clinics/Details/{identifier.EncodeId(this.Id, this.Name)}";
            }
        }

        public int PetsCount { get; set; }

        public double RatingCount { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Clinic, ClinicViewModel>()
                .ForMember(x => x.CityName, opts => opts.MapFrom(x => x.City.Name))
                .ForMember(x => x.RatingCount, opts => opts.MapFrom(x => x.Ratings.Any() ? x.Ratings.Average(r => r.Value) : 0.0))
                .ForMember(x => x.PetsCount, opts => opts.MapFrom(x => x.Pets.Count() != 0 ? x.Pets.Count() : 0));
        }
    }
}
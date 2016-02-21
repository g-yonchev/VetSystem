using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VetSystem.Data.Models;
using VetSystem.Web.Infrastructure.Mapping;

namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    public class ClinicDetailsViewModel : IMapFrom<Clinic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PetsCount { get; set; }

        public double RatingCount { get; set; }

        public string Information { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Clinic, ClinicDetailsViewModel>()
                .ForMember(x => x.CityName, opts => opts.MapFrom(x => x.City.Name))
                .ForMember(x => x.RatingCount, opts => opts.MapFrom(x => x.Ratings.Any() ? x.Ratings.Average(r => r.Value) : 0.0))
                .ForMember(x => x.PetsCount, opts => opts.MapFrom(x => x.Pets.Count() != 0 ? x.Pets.Count() : 0));
        }
    }
}
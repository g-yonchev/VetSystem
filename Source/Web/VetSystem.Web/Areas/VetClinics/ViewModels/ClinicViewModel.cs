using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VetSystem.Data.Models;
using VetSystem.Web.Infrastructure.Mapping;

namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    public class ClinicViewModel : IMapFrom<Clinic>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }

        public int PetsCount { get; set; }

        public string OwnerName { get; set; }

        public int RatingCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Clinic, ClinicViewModel>()
                .ForMember(x => x.OwnerName, opts => opts.MapFrom(x => x.Owner.UserName))
                .ForMember(x => x.RatingCount, opts => opts.MapFrom(x => x.Ratings.Any() ? x.Ratings.Sum(r => r.Value) : 0))
                .ForMember(x => x.PetsCount, opts => opts.MapFrom(x => x.Pets.Count() != 0 ? x.Pets.Count() : 0));
        }
    }
}
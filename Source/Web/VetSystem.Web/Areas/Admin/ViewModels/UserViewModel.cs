namespace VetSystem.Web.Areas.Admin.ViewModels
{
    using System;
    using System.Linq;

    using AutoMapper;

    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public int PetsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(x => x.PetsCount, opts => opts.MapFrom(x => x.Pets.Any() ? x.Pets.Count() : 0));
        }
    }
}
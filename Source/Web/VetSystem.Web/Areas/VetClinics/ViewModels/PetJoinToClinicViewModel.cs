using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetSystem.Data.Models;
using VetSystem.Web.Infrastructure.Mapping;

namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    public class PetJoinToClinicViewModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
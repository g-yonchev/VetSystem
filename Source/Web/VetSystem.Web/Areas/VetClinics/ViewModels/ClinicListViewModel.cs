using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    public class ClinicListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ClinicViewModel> Clinics { get; set; }
    }
}
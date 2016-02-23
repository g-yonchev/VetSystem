namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    using System.Collections.Generic;

    public class ClinicListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ClinicViewModel> Clinics { get; set; }
    }
}
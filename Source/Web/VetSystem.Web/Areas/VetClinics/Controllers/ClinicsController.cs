namespace VetSystem.Web.Areas.VetClinics.Controllers
{
    using Infrastructure.Mapping;
    using System.Linq;
    using System.Web.Mvc;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.VetClinics.ViewModels;

    public class ClinicsController : Controller
    {
        private IClinicsService clinics;

        public ClinicsController(IClinicsService clinics)
        {
            this.clinics = clinics;
        }

        public ActionResult Index()
        {
            var clinics = this.clinics
                .GetAll()
                .To<ClinicViewModel>()
                .ToList();

            return View(clinics);
        }
    }
}
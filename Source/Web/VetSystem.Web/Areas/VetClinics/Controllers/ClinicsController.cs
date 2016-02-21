namespace VetSystem.Web.Areas.VetClinics.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.VetClinics.ViewModels;
    using VetSystem.Web.Controllers;
    using VetSystem.Web.Infrastructure.Mapping;

    public class ClinicsController : BaseController
    {
        private readonly IClinicsService clinics;

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

            return this.View(clinics);
        }

        public ActionResult Details(int id)
        {
            var clinic = this.clinics
                .GetById(id)
                .To<ClinicDetailsViewModel>()
                .FirstOrDefault();

            return this.View(clinic);
        }
    }
}
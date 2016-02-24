namespace VetSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Infrastructure.Mapping;
    using VetSystem.Web.ViewModels.Clinics;

    public class HomeController : BaseController
    {
        private const int TimeForCache = 60 * 60;
        private const int NumberOfTopClinics = 5;

        private readonly IClinicsService clinics;

        public HomeController(IClinicsService clinics)
        {
            this.clinics = clinics;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetClinicsRatedPartial()
        {
            var clinics =
                this.Cache.Get(
                    "ClinicsRated",
                    () => this.clinics
                        .MostRated(NumberOfTopClinics)
                        .To<ClinicSimpleRatedViewModel>()
                        .ToList(),
                        TimeForCache);

            return this.PartialView("_SimpleClinicsRatedPartial", clinics);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetClinicsTopPetsCountPartial()
        {
            var clinics =
                this.Cache.Get(
                    "ClinicsTopPetsCount",
                    () => this.clinics
                        .TopPetsCount(NumberOfTopClinics)
                        .To<ClinicSimpleToPetCountViewModel>()
                        .ToList(),
                        TimeForCache);

            return this.PartialView("_SimpleClinicsPetsPartial", clinics);
        }
    }
}
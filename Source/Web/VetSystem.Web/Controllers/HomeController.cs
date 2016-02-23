namespace VetSystem.Web.Controllers
{
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Clinics;
    public class HomeController : BaseController
	{
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
                        .MostRated(5)
                        .To<ClinicSimpleRatedViewModel>()
                        .ToList(),
                        60 * 60);

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
                        .TopPetsCount(5)
                        .To<ClinicSimpleToPetCountViewModel>()
                        .ToList(),
                        60 * 60);

            return this.PartialView("_SimpleClinicsPetsPartial", clinics);
        }
    }
}
namespace VetSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using VetSystem.Common.Constants;
    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.Admin.ViewModels;
    using VetSystem.Web.Areas.Pets.ViewModels;
    using VetSystem.Web.Controllers;
    using VetSystem.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class PetsController : BaseController
    {
        private readonly IPetsService pets;
        private readonly ISpeciesService species;

        public PetsController(IPetsService pets, ISpeciesService species)
        {
            this.pets = pets;
            this.species = species;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetSpecies()
        {
            var species = this.species
                .GetAll()
                .To<SpeciesViewModel>()
                .ToList();

            return this.Json(species, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.pets
               .GetAll()
               .To<PetAdminViewModel>()
               .ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, PetAdminViewModel pet)
        {
            if (this.ModelState.IsValid && pet != null)
            {
                this.pets.Update(pet.Id, pet.Name, pet.Age, pet.Species.Id);
            }

            return this.Json(new[] { pet }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, PetAdminViewModel pet)
        {
            this.pets.Delete(pet.Id);

            return this.Json(new[] { pet }.ToDataSourceResult(request, this.ModelState));
        }
    }
}

namespace VetSystem.Web.Controllers
{
	using System.Linq;
	using System.Web.Mvc;

	using VetSystem.Services.Data.Contracts;
	using VetSystem.Web.Infrastructure.Mapping;
	using VetSystem.Web.ViewModels.Pets;

	public class PetsController : BaseController
    {
		private IPetsService pets;

		public PetsController(IPetsService pets)
		{
			this.pets = pets;
		}

        // GET: Pets
        public ActionResult Index()
        {
			var pets = this.pets
				.GetMine(this.User.Identity.Name).To<PetViewModel>().ToList();
            return View(pets);
        }
    }
}
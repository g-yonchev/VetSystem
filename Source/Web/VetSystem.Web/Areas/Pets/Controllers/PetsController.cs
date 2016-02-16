namespace VetSystem.Web.Areas.Pets.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.Pets.ViewModels;
    using VetSystem.Web.Controllers;
    using VetSystem.Web.Infrastructure.Mapping;

    public class PetsController : BaseController
    {
		private IPetsService pets;

		public PetsController(IPetsService pets)
		{
			this.pets = pets;
		}
        
        public ActionResult Index()
        {
			var pets = this.pets
				.GetMine(this.User.Identity.Name).To<PetViewModel>().ToList();
            return View(pets);
        }
    }
}
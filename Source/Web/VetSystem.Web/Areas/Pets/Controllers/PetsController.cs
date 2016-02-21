namespace VetSystem.Web.Areas.Pets.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.Pets.ViewModels;
    using VetSystem.Web.Controllers;
    using VetSystem.Web.Infrastructure.Mapping;
    using Data.Models;
    using System.Collections.Generic;
    public class PetsController : BaseController
    {
		private IPetsService pets;

		public PetsController(IPetsService pets)
		{
			this.pets = pets;
		}
        
        [HttpGet]
        public ActionResult Index()
        {
			var pets = this.pets
				.GetMine(this.User.Identity.Name)
                .To<PetViewModel>()
                .ToList();

            return this.View(pets);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();

            var pet = this.pets.Create(
                model.Name,
                model.Age,
                userId,
                model.Gender,
                model.Species);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var pet = this.pets.GetById(id);

            var viewModel = new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                ClinicName = pet.Clinic.Name
            };
            
            return this.View(viewModel);
        }
    }
}
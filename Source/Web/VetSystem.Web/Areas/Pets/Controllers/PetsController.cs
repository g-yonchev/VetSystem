namespace VetSystem.Web.Areas.Pets.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.Pets.ViewModels;
    using VetSystem.Web.Infrastructure.Mapping;
    using VetClinics.ViewModels;

    public class PetsController : BaseController
    {
        private readonly IPetsService pets;
        private readonly ISpeciesService species;

        public PetsController(IPetsService pets, ISpeciesService species, IUsersService users)
            : base(users)
        {
            this.pets = pets;
            this.species = species;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.CurrentUser.Id;

            var pets = this.pets
                .GetMineByUserId(userId)
                .To<PetViewModel>()
                .ToList();

            return this.View(pets);
        }

        [HttpGet]
        public ActionResult GetUserPets()
        {
            var userId = this.CurrentUser.Id;

            var pets = this.pets.GetMineByUserId(userId)
                .To<PetJoinToClinicViewModel>()
                .ToList();

            return this.Json(pets, JsonRequestBehavior.AllowGet);
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
            if (model == null || !this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var imageUrl = string.Empty;
            if (model.File != null)
            {
                if (model.File.ContentType != "image/jpeg" && model.File.ContentLength >= 1048576)
                {
                    return this.View(model);
                }

                string filename = Path.GetFileName(model.File.FileName);
                string folderPath = Server.MapPath("~/Content/Images/" + this.CurrentUser.Id);
                string imagePath = folderPath + "/" + filename;
                imageUrl = "/Content/Images/" + this.CurrentUser.Id + "/" + filename;

                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                }

                model.File.SaveAs(imagePath);
            }

            var userId = this.User.Identity.GetUserId();

            var pet = this.pets.Create(
                model.Name,
                model.Age,
                userId,
                model.Gender,
                model.SpeciesId,
                imageUrl);

            return this.RedirectToAction("Details", new { id = pet.Id });
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var pet = this.pets
                .GetById(id)
                .To<PetViewModel>()
                .FirstOrDefault();

            return this.View(pet);
        }

        public ActionResult GetSpecies()
        {
            var species = this.species
                .GetAll()
                .To<SpeciesViewModel>()
                .ToList();

            return this.Json(species, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JoinPetToClinic(int clinicId, int petId)
        {
            this.pets.AddToClinic(petId, clinicId);

            return this.RedirectToAction("Details", new { id = petId });
        }
    }
}
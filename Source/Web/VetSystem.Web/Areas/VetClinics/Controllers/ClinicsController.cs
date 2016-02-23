namespace VetSystem.Web.Areas.VetClinics.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.VetClinics.ViewModels;
    using VetSystem.Web.Controllers;
    using VetSystem.Web.Infrastructure.Mapping;

    public class ClinicsController : BaseController
    {
        private const int ItemsPerPage = 3;
        private readonly IClinicsService clinics;

        public ClinicsController(IClinicsService clinics)
        {
            this.clinics = clinics;
        }

        public ActionResult Index(int id = 1)
        {
            ClinicListViewModel viewModel;

            var page = id;
            var allItemsCount = this.clinics.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var clinics = this.clinics.GetAll()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<ClinicViewModel>()
                .ToList();

            viewModel = new ClinicListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Clinics = clinics
            };

            return this.View(viewModel);
        }

        public ActionResult Details(string id)
        {
            var clinic = this.clinics
                .GetById(id)
                .To<ClinicDetailsViewModel>()
                .FirstOrDefault();

            return this.View(clinic);
        }
    }
}
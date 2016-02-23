namespace VetSystem.Web.Areas.ClinicOwner.Controllers
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using VetSystem.Data;
    using VetSystem.Web.Areas.ClinicOwner.ViewModels;
    using VetSystem.Web.Controllers;

    public class SchedulerController : BaseController
    {
        private VetSystemDbContext db = new VetSystemDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        public ActionResult Tasks_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.db.Tasks.ToList()
                        .Select(task => new TaskViewModel(task))
                        .AsQueryable();

            return this.Json(data.ToDataSourceResult(request));
        }

        public virtual JsonResult Tasks_Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (this.ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(task.Title))
                {
                     task.Title = string.Empty;
                }

                var entity = task.ToEntity();
                this.db.Tasks.Add(entity);
                this.db.SaveChanges();
                task.Id = entity.Id;
            }

            return this.Json(new[] { task }.ToDataSourceResult(request, this.ModelState));
        }

        public virtual JsonResult Tasks_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (this.ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(task.Title))
                {
                     task.Title = string.Empty;
                }

                var entity = task.ToEntity();
                this.db.Tasks.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { task }.ToDataSourceResult(request, this.ModelState));
        }

        public virtual JsonResult Tasks_Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (this.ModelState.IsValid)
            {
                var entity = task.ToEntity();
                this.db.Tasks.Attach(entity);
                this.db.Tasks.Remove(entity);
                this.db.SaveChanges();
            }

            return this.Json(new[] { task }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
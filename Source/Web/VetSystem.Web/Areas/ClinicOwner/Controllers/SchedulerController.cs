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
            var data = db.Tasks.ToList()
                        .Select(task => new TaskViewModel(task))
                        .AsQueryable();

            return this.Json(data.ToDataSourceResult(request));
        }

        public virtual JsonResult Tasks_Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty( task.Title))
                {
                     task.Title = "";
                }

                var entity = task.ToEntity();
                db.Tasks.Add(entity);
                db.SaveChanges();
                task.Id = entity.Id;
            }

            return this.Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }
        public virtual JsonResult Tasks_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty( task.Title))
                {
                     task.Title = "";
                }

                var entity = task.ToEntity();
                db.Tasks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return this.Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }
        public virtual JsonResult Tasks_Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                var entity = task.ToEntity();
                db.Tasks.Attach(entity);
                db.Tasks.Remove(entity);
                db.SaveChanges();
            }

            return this.Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
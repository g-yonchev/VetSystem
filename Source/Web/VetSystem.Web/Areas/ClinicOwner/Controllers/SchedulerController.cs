using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VetSystem.Data.Models;
using VetSystem.Data;

namespace VetSystem.Web.Areas.ClinicOwner.Controllers
{
    public class SchedulerController : Controller
    {
        private VetSystemDbContext db = new VetSystemDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        public ActionResult Tasks_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = db.Tasks.ToList()
                        .Select(task => new TaskViewModel(task))
                        .AsQueryable();

            return Json(data.ToDataSourceResult(request));
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

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
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

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
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

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
namespace VetSystem.Web.Areas.Admin.Controllers
{
    using System;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using VetSystem.Common.Constants;
    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Areas.Admin.ViewModels;
    using VetSystem.Web.Controllers;
    using VetSystem.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.users
                .GetAll()
                .To<UserAdminViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserAdminViewModel user)
        {
            if (this.ModelState.IsValid && user != null)
            {
                this.users.Update(user.Id, user.UserName, user.Email, user.PhoneNumber);
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, UserAdminViewModel user)
        {
            this.users.Delete(user.Id);

            return this.Json(new[] { user }.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}

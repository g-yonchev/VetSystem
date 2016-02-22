using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetSystem.Data.Common.Repositories;
using VetSystem.Data.Models;
using VetSystem.Services.Data.Contracts;
using VetSystem.Web.Areas.Admin.ViewModels;
using VetSystem.Web.Controllers;

namespace VetSystem.Web.Areas.Admin.Controllers
{
    public class UserCreateController : BaseController
    {
        private readonly IUsersService users;

        public UserCreateController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(UserCreateViewModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.View();
            }

            if (model.IsClinicOwner)
            {
                this.users.CreateUserAsClinicOwner(model.Email, model.Password);
            }
            else
            {
                this.users.CreateUserAsClient(model.Email, model.Password);
            }

            return this.RedirectToAction("Index", "Users", null);
        }
    }
}
namespace VetSystem.Web.Areas.Pets.Controllers
{
    using System;
    using System.Web.Routing;

    using Microsoft.AspNet.Identity;

    using VetSystem.Data.Models;
    using VetSystem.Services.Data.Contracts;

    using Base = VetSystem.Web.Controllers.BaseController;

    public class BaseController : Base
    {
        public BaseController(IUsersService users)
        {
            this.Users = users;
        }

        protected User CurrentUser { get; private set; }

        private new IUsersService Users { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.Users.GetById(requestContext.HttpContext.User.Identity.GetUserId());

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
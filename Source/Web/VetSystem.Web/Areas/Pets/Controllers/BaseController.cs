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
        private IUsersService users { get; set; }

        public BaseController(IUsersService users)
        {
            this.users = users;
        }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.users.GetById(requestContext.HttpContext.User.Identity.GetUserId());

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
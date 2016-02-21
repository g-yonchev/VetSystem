namespace VetSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper;

    using Microsoft.AspNet.Identity;

    using VetSystem.Services.Data.Contracts;
    using VetSystem.Services.Web;
    using VetSystem.Web.Infrastructure.Mapping;
    using VetSystem.Web.ViewModels.Users;

    public abstract class BaseController : Controller
	{
        public IUsersService Users { get; set; }

		public ICacheService Cache { get; set; }

		protected IMapper Mapper
		{
			get
			{
				return AutoMapperConfig.Configuration.CreateMapper();
			}
		}

		protected bool IsAuthenticatedUser
		{
			get
			{
				return this.HttpContext.User.Identity.IsAuthenticated;
			}
		}

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var id = requestContext.HttpContext.User.Identity.GetUserId();
                var user = this.Users.GetById(id);
                
                var pets = user.Pets.AsQueryable().To<PetForMenuViewModel>().ToList();

                this.ViewBag.PetsMenu = pets;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
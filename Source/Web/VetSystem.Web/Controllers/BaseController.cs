namespace VetSystem.Web.Controllers
{
    using System;
    using System.Web.Routing;
    using System.Web.Mvc;

    using AutoMapper;

    using VetSystem.Services.Web;
    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using ViewModels.Users;
    using System.Linq;
    using Services.Data;
    using Data.Models;
    using Data.Common.Repositories;
    public abstract class BaseController : Controller
	{
        private IUsersService users = new UsersService(new DbRepository<User>(new Data.VetSystemDbContext()));

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
                var user = this.users.GetById(id);
                
                var pets = user.Pets.AsQueryable().To<PetForMenuViewModel>().ToList();

                this.ViewBag.PetsMenu = pets;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
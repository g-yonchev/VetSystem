namespace VetSystem.Web.Controllers
{
	using System.Web.Mvc;

	using AutoMapper;

	using VetSystem.Services.Web;
	using VetSystem.Web.Infrastructure.Mapping;

	public abstract class BaseController : Controller
	{
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
	}
}
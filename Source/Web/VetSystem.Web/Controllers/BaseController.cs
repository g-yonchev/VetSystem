namespace VetSystem.Web.Controllers
{
	using AutoMapper;
	using System.Web.Mvc;

	using VetSystem.Web.Infrastructure.Mapping;

	public abstract class BaseController : Controller
	{
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
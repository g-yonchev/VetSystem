namespace VetSystem.Web
{
	using System.Data.Entity;
	using System.Reflection;
	using System.Web.Mvc;

	using Autofac;
	using Autofac.Integration.Mvc;

	using VetSystem.Data;
	using VetSystem.Data.Common.Repositories;
	using VetSystem.Services.Data.Contracts;
	using VetSystem.Services.Web;
	using VetSystem.Web.Controllers;

	public static class AutofacConfig
	{
		public static void RegisterAutofac()
		{
			var builder = new ContainerBuilder();

			// Register your MVC controllers.
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// OPTIONAL: Register model binders that require DI.
			builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
			builder.RegisterModelBinderProvider();

			// OPTIONAL: Register web abstractions like HttpContextBase.
			builder.RegisterModule<AutofacWebTypesModule>();

			// OPTIONAL: Enable property injection in view pages.
			builder.RegisterSource(new ViewRegistrationSource());

			// OPTIONAL: Enable property injection into action filters.
			builder.RegisterFilterProvider();

			// Register services
			RegisterServices(builder);

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}

		private static void RegisterServices(ContainerBuilder builder)
		{
			builder.Register(x => new VetSystemDbContext())
				 .As<DbContext>()
				 .InstancePerRequest();

			builder.RegisterGeneric(typeof(DbRepository<>))
				.As(typeof(IDbRepository<>))
				.InstancePerRequest();

			builder.Register(x => new HttpCacheService())
				.As<ICacheService>()
				.InstancePerRequest();

			var servicesAssembly = Assembly.GetAssembly(typeof(IPetsService));
			builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.AssignableTo<BaseController>().PropertiesAutowired();
		}
	}
}
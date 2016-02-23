namespace VetSystem.Web.Areas.Pets
{
    using System.Web.Mvc;

    public class PetsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Pets";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Pets_default",
                "Pets/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
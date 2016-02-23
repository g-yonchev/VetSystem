namespace VetSystem.Web.Areas.VetClinics
{
    using System.Web.Mvc;

    public class VetClinicsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VetClinics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VetClinics_default",
                "VetClinics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
using System.Web.Mvc;

namespace VetSystem.Web.Areas.ClinicOwner
{
    public class ClinicOwnerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ClinicOwner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ClinicOwner_default",
                "ClinicOwner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
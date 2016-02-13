namespace VetSystem.Web
{
	using System.Web.Mvc;

	public class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CSharpRazorViewEngine());
        }
    }

    public class CSharpRazorViewEngine : RazorViewEngine
    {
        public CSharpRazorViewEngine()
        {
            this.AreaViewLocationFormats = new[]
            {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            this.AreaMasterLocationFormats = new[]
            {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            this.AreaPartialViewLocationFormats = new[]
            {
            "~/Areas/{2}/Views/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            this.ViewLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
            };

            this.MasterLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
            };

            this.PartialViewLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml"
            };
        }
    }
}
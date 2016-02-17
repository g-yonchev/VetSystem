namespace VetSystem.Web.Filters
{
    using System.Web.Mvc;

    public class ValidateRatingValueAttribute : ActionFilterAttribute
    {
        private int minValue;
        private int maxValue;

        public ValidateRatingValueAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ratingValue = (int)filterContext.ActionParameters["ratingValue"];

            if (ratingValue < this.minValue)
            {
                ratingValue = this.minValue;
            }

            if (ratingValue > this.maxValue)
            {
                ratingValue = this.maxValue;
            }

            filterContext.ActionParameters["ratingValue"] = ratingValue;

            base.OnActionExecuting(filterContext);
        }
    }
}
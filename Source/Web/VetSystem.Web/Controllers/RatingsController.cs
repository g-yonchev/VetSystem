namespace VetSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using VetSystem.Common.Constants;
    using VetSystem.Services.Data.Contracts;
    using VetSystem.Web.Filters;

    public class RatingsController : Controller
    {
        private IRatingsService ratings;

        public RatingsController(IRatingsService ratings)
        {
            this.ratings = ratings;
        }

        [HttpPost]
        [ValidateRatingValue(ValidationConstants.MinRatingValue, ValidationConstants.MaxRatingValue)]
        public ActionResult Rate(int itemId, int ratingValue)
        {
            var userId = this.User.Identity.GetUserId();
            var rating = this.ratings.Rate(itemId, userId, ratingValue);
            return this.Json(new { Rating = rating });
        }
    }
}
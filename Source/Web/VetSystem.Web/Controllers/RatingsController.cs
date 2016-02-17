using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetSystem.Data.Common.Repositories;
using VetSystem.Data.Models;
using VetSystem.Services.Data.Contracts;

namespace VetSystem.Web.Controllers
{
    public class RatingsController : Controller
    {
        private IRatingsService ratings;

        public RatingsController(IRatingsService ratings)
        {
            this.ratings = ratings;
        }

        [HttpPost]
        public ActionResult Rate(int clinicId, int ratingValue)
        {
            var userId = this.User.Identity.GetUserId();
            var rating = this.ratings.Rate(clinicId, userId, ratingValue);
            return this.Json(new { Count = rating });
        }
    }
}
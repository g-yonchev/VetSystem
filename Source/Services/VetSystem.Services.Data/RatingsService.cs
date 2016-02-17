using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Data.Common.Repositories;
using VetSystem.Data.Models;
using VetSystem.Services.Data.Contracts;

namespace VetSystem.Services.Data
{
    public class RatingsService : IRatingsService
    {
        private IDbRepository<Rating> ratings;

        public RatingsService(IDbRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public int Rate(int clinicId, string userId, int ratingValue)
        {
            if (ratingValue < 0)
            {
                ratingValue = 0;
            }

            if (ratingValue > 5)
            {
                ratingValue = 5;
            }

            var rating = this.ratings.All().FirstOrDefault(x => x.AuthorId == userId && x.ClinicId == clinicId);

            if (rating == null)
            {
                rating = new Rating()
                {
                    AuthorId = userId,
                    ClinicId = clinicId,
                    Value = ratingValue
                };

                this.ratings.Add(rating);
            }
            else
            {
                rating.Value = ratingValue;
            }

            this.ratings.Save();

            int clinicRating = this.ratings.All().Where(x => x.ClinicId == clinicId).Sum(x => x.Value);

            return clinicRating;
        }
    }
}

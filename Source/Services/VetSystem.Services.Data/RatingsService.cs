namespace VetSystem.Services.Data
{
    using System.Linq;

    using VetSystem.Data.Common.Repositories;
    using VetSystem.Data.Models;
    using VetSystem.Services.Data.Contracts;

    public class RatingsService : IRatingsService
    {
        private readonly IDbRepository<Rating> ratings;

        public RatingsService(IDbRepository<Rating> ratings)
        {
            this.ratings = ratings;
        }

        public double Rate(int clinicId, string userId, int ratingValue)
        {
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

            double clinicRating = this.ratings
                .All()
                .Where(x => x.ClinicId == clinicId)
                .Average(x => x.Value);

            return clinicRating;
        }
    }
}

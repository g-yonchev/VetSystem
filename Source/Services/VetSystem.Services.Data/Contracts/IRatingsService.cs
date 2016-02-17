namespace VetSystem.Services.Data.Contracts
{
    public interface IRatingsService
    {
        double Rate(int clinicId, string userId, int ratingValue);
    }
}

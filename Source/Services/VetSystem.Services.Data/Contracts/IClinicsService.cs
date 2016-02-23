namespace VetSystem.Services.Data.Contracts
{
    using System.Linq;

    using VetSystem.Data.Models;

    public interface IClinicsService
    {
        IQueryable<Clinic> GetAll();

        IQueryable<Clinic> GetById(string id);

        IQueryable<Clinic> MostRated(int count);

        IQueryable<Clinic> TopPetsCount(int count);
    }
}

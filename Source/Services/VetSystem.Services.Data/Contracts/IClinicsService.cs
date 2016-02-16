namespace VetSystem.Services.Data.Contracts
{
    using System.Linq;

    using VetSystem.Data.Models;

    public interface IClinicsService
    {
        IQueryable<Clinic> GetAll();
    }
}

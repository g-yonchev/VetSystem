namespace VetSystem.Services.Data.Contracts
{
    using System.Linq;

    using VetSystem.Data.Models;

    public interface ICitiesService
    {
        IQueryable<City> GetAll();

        City GetById(int id);

        City Create(string name);
    }
}

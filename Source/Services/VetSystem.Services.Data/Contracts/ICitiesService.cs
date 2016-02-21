using System.Linq;
using VetSystem.Data.Models;

namespace VetSystem.Services.Data.Contracts
{
    public interface ICitiesService
    {
        IQueryable<City> GetAll();

        City GetById(int id);

        City Create(string name);
    }
}

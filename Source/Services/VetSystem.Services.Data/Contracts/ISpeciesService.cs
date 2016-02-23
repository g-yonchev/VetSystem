namespace VetSystem.Services.Data.Contracts
{
    using System.Linq;

    using VetSystem.Data.Models;

    public interface ISpeciesService
    {
        IQueryable<PetSpecies> GetAll();

        PetSpecies Ensure(string name);
    }
}

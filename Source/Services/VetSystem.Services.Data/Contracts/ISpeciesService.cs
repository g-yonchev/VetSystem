using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Data.Models;

namespace VetSystem.Services.Data.Contracts
{
    public interface ISpeciesService
    {
        IQueryable<PetSpecies> GetAll();

        PetSpecies Ensure(string name);
    }
}

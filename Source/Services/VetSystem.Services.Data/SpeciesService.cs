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
    public class SpeciesService : ISpeciesService
    {
        private IDbRepository<PetSpecies> species;

        public SpeciesService(IDbRepository<PetSpecies> species)
        {
            this.species = species;
        }

        public PetSpecies Ensure(string name)
        {
            var species = this.species.All().FirstOrDefault(x => x.Name == name);

            if (species == null)
            {
                species = new PetSpecies
                {
                    Name = name
                };

                this.species.Add(species);
                this.species.Save();
            }

            return species;
        }

        public IQueryable<PetSpecies> GetAll()
        {
            var species = this.species.All();
            return species;
        }
    }
}

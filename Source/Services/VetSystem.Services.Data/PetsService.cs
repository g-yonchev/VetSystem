namespace VetSystem.Services.Data
{
	using System;
	using System.Linq;

	using VetSystem.Data.Common.Repositories;
	using VetSystem.Data.Models;
	using VetSystem.Services.Data.Contracts;

	public class PetsService : IPetsService
	{
		private IDbRepository<Pet> pets;
        private IDbRepository<PetSpecies> species;
        private IDbRepository<Clinic> clinics;

		public PetsService(IDbRepository<Pet> pets, IDbRepository<PetSpecies> species, IDbRepository<Clinic> clinics)
		{
			this.pets = pets;
            this.species = species;
            this.clinics = clinics;
		}

		public Pet GetById(int id)
		{
			var pet = this.pets.GetById(id);
			return pet;
		}

		public IQueryable<Pet> GetByName(string name)
		{
			// TODO: Order by something later
			var pets = this.pets.All().Where(x => x.Name == name);
			return pets;
		}

		public IQueryable<Pet> GetAll()
		{
			// TODO: Order by something later
			var pets = this.pets.All();
			return pets;
		}

		public IQueryable<Pet> Get(int count)
		{
			// TODO: Order by something later
			var pets = this.pets.All().Take(count);
			return pets;
		}


        public Pet Create(string name, int age, string ownerId, PetGender gender, string species)
		{
            var speciesDb = this.species.All().FirstOrDefault(x => x.Name == species);
            var clinic = this.clinics.All().FirstOrDefault();

            var pet = new Pet
            {
                Name = name,
                Age = age,
                OwnerId = ownerId,
                Gender = gender,
                Species = speciesDb,
                // TODO: Remove!!!!
                Clinic = clinic
			};

			this.pets.Add(pet);
			this.pets.Save();

			return pet;
		}

		public IQueryable<Pet> GetMine(string user)
		{
			var pets = this.pets.All().Where(x => x.Owner.Email == user);
			return pets;
		}
	}
}

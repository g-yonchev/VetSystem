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
        private IDbRepository<Clinic> clinics;

		public PetsService(IDbRepository<Pet> pets, IDbRepository<Clinic> clinics)
		{
			this.pets = pets;
            this.clinics = clinics;
		}

		public IQueryable<Pet> GetById(int id)
		{
            return this.pets.All().Where(x => x.Id == id);
		}

		public IQueryable<Pet> GetByName(string name)
		{
			var pets = this.pets.All().Where(x => x.Name == name);
			return pets;
		}

		public IQueryable<Pet> GetAll()
		{
			var pets = this.pets.All().OrderBy(x => x.Id);
			return pets;
		}

		public IQueryable<Pet> Get(int count)
		{
			var pets = this.pets.All().Take(count).OrderByDescending(x => x.CreatedOn);
			return pets;
		}


        public Pet Create(string name, int age, string ownerId, PetGender gender, int speciesId, string picture = null)
		{
            var clinic = this.clinics.All().FirstOrDefault();

            if (picture == null)
            {
                picture = "default picture";
            }

            var pet = new Pet
            {
                Name = name,
                Age = age,
                OwnerId = ownerId,
                Clinic = clinic,
                Gender = gender,
                SpeciesId = speciesId,
                Picture = picture
			};

			this.pets.Add(pet);
			this.pets.Save();

			return pet;
		}

		public IQueryable<Pet> GetMine(string user)
		{
			var pets = this.pets.All().Where(x => x.Owner.Email == user).OrderByDescending(x => x.CreatedOn);
			return pets;
		}
	}
}

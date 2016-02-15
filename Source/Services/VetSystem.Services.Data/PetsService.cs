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

		public PetsService(IDbRepository<Pet> pets)
		{
			this.pets = pets;
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

		public Pet Create(string name, string ownerId)
		{
			var pet = new Pet
			{
				Name = name,
				OwnerId = ownerId
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

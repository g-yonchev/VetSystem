namespace VetSystem.Services.Data
{
    using System.Linq;

    using VetSystem.Data.Common.Repositories;
    using VetSystem.Data.Models;
    using VetSystem.Services.Data.Contracts;

    public class PetsService : IPetsService
    {
        private readonly IDbRepository<Pet> pets;
        private readonly IDbRepository<Clinic> clinics;

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
            if (picture == string.Empty)
            {
                picture = "http://s.hswstatic.com/gif/animal-stereotype-orig.jpg";
            }

            var pet = new Pet
            {
                Name = name,
                Age = age,
                OwnerId = ownerId,
                Gender = gender,
                SpeciesId = speciesId,
                Picture = picture
            };

            this.pets.Add(pet);
            this.pets.Save();

            return pet;
        }

        public IQueryable<Pet> GetMineByUserName(string userName)
        {
            var pets = this.pets.All().Where(x => x.Owner.UserName == userName).OrderByDescending(x => x.CreatedOn);
            return pets;
        }

        public IQueryable<Pet> GetMineByUserId(string userId)
        {
            var pets = this.pets.All().Where(x => x.Owner.Id == userId).OrderByDescending(x => x.CreatedOn);
            return pets;
        }

        public void AddToClinic(int petId, int clinicId)
        {
            var pet = this.pets.GetById(petId);

            pet.ClinicId = clinicId;

            this.pets.Save();
        }

        public void Delete(int id)
        {
            var pet = this.pets.GetById(id);

            if (pet != null)
            {
                this.pets.Delete(pet);
                this.pets.Save();
            }
        }

        public void Update(int id, string name, int age, int speciesId)
        {
            var pet = this.pets.GetById(id);
            if (pet != null)
            {
                pet.Name = name;
                pet.Age = age;
                pet.SpeciesId = speciesId;

                this.pets.Save();
            }
        }
    }
}

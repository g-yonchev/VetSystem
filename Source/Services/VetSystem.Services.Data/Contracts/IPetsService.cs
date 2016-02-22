namespace VetSystem.Services.Data.Contracts
{
	using System.Linq;

	using VetSystem.Data.Models;

	public interface IPetsService
	{
		IQueryable<Pet> GetAll();

		IQueryable<Pet> GetMineByUserName(string userName);

        IQueryable<Pet> GetMineByUserId(string userId);

        IQueryable<Pet> Get(int count);

        IQueryable<Pet> GetById(int id);

		IQueryable<Pet> GetByName(string name);

		Pet Create(string name, int age, string ownerId, PetGender gender, int speciesId, string picture = null);

        void AddToClinic(int petId, int clinicId);

        void Delete(int id);

        void Update(int id, string name, int age, int speciesId);
    }
}

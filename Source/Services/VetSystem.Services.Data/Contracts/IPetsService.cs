namespace VetSystem.Services.Data.Contracts
{
	using System.Linq;

	using VetSystem.Data.Models;

	public interface IPetsService
	{
		IQueryable<Pet> GetAll();

		IQueryable<Pet> Get(int count);

		Pet GetById(int id);

		IQueryable<Pet> GetByName(string name);

		Pet Create(string name, string ownerId);
	}
}

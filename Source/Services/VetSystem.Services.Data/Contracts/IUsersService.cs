namespace VetSystem.Services.Data.Contracts
{
    using System.Linq;

    using VetSystem.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User CreateUserAsClient(string username, string password);

        User CreateUserAsClinicOwner(string username, string password);

        void Update(string id, string username, string email, string phoneNumber);

        void Delete(string id);
    }
}

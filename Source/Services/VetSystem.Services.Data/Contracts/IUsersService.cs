using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Data.Models;

namespace VetSystem.Services.Data.Contracts
{
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

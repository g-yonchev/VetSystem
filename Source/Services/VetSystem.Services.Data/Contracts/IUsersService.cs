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

        void Update();

        void AddUser(User user, string password);

        void Delete(string id);
    }
}

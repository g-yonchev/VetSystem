using Microsoft.AspNet.Identity;
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
    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public void AddUser(User user, string password)
        {
            user.PasswordHash = new PasswordHasher().HashPassword(password);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = user.Email;
            this.users.Add(user);
            this.users.Save();
        }

        public void Delete(string id)
        {
            var user = this.users.GetById(id);
            if (user == null)
            {
                throw new NullReferenceException("No such user id");
            }

            this.users.Delete(user);
            this.users.Save();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All().OrderBy(x => x.Id);
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public void Update()
        {
            this.users.Save();
            throw new NotImplementedException();
        }
    }
}

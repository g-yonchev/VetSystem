namespace VetSystem.Services.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using VetSystem.Data;
    using VetSystem.Data.Common.Repositories;
    using VetSystem.Data.Models;
    using VetSystem.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public User CreateUserAsClient(string username, string password)
        {
            var user = new User
            {
                UserName = username,
                Email = username,
                PasswordHash = new PasswordHasher().HashPassword(password),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            
            this.users.Add(user);
            this.users.Save();

            return user;
        }

        public User CreateUserAsClinicOwner(string username, string password)
        {
            var user = new User
            {
                UserName = username,
                Email = username,
                PasswordHash = new PasswordHasher().HashPassword(password),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var db = new VetSystemDbContext();

            var clinicOwnerRole = db.Roles.Where(r => r.Name == "ClinicOwner").FirstOrDefault();
            var role = new IdentityUserRole
            {
                RoleId = clinicOwnerRole.Id
            };

            this.users.Add(user);
			user.Roles.Add(role);
            db.Dispose();
            this.users.Save();

            return user;
        }

        public void Update(string id, string username, string email, string phoneNumber)
        {
            var user = this.users.GetById(id);

            user.Email = email;
            user.UserName = username;
            user.PhoneNumber = phoneNumber;

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
    }
}

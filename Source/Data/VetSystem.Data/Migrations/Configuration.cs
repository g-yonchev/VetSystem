namespace VetSystem.Data.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.Linq;

	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	using VetSystem.Data.Models;

	public sealed class Configuration : DbMigrationsConfiguration<VetSystemDbContext>
	{
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(VetSystemDbContext context)
		{
			// Roles
			context.Roles.Add(new IdentityRole { Name = "Administrator" });
			context.Roles.Add(new IdentityRole { Name = "ClinicOwner" });
			context.SaveChanges();

			// Admin User
			var admin = new User
			{
				UserName = "admin@admin.com",
				Email = "admin@admin.com",
				PasswordHash = new PasswordHasher().HashPassword("admin@admin.com"),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			context.Users.Add(admin);

			var adminRoleDb = context.Roles.Where(r => r.Name == "Administrator").FirstOrDefault();
			var adminRole = new IdentityUserRole
			{
				RoleId = adminRoleDb.Id
			};

			admin.Roles.Add(adminRole);
			context.SaveChanges();

			// Clinic Owner Users
			var clinicOwners = new List<User>();

			var clinicOwnerRoleDbBluecross = context.Roles.Where(r => r.Name == "ClinicOwner").FirstOrDefault();
			var clinicOwnerRoleBluecross = new IdentityUserRole
			{
				RoleId = clinicOwnerRoleDbBluecross.Id
			};

			var bluecrossClinic = new User
			{
				UserName = "bluecross@vet.com",
				Email = "bluecross@vet.com",
				PasswordHash = new PasswordHasher().HashPassword("bluecross@vet.com"),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			clinicOwners.Add(bluecrossClinic);
			context.Users.Add(bluecrossClinic);
			bluecrossClinic.Roles.Add(clinicOwnerRoleBluecross);

			var clinicOwnerRoleDbRedcross = context.Roles.Where(r => r.Name == "ClinicOwner").FirstOrDefault();
			var clinicOwnerRoleRedcross = new IdentityUserRole
			{
				RoleId = clinicOwnerRoleDbRedcross.Id
			};

			var redcrossClinic = new User
			{
				UserName = "redcross@vet.com",
				Email = "redcross@vet.com",
				PasswordHash = new PasswordHasher().HashPassword("redcross@vet.com"),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			clinicOwners.Add(redcrossClinic);
			context.Users.Add(redcrossClinic);
			redcrossClinic.Roles.Add(clinicOwnerRoleRedcross);

			var clinicOwnerRoleDbGreendo = context.Roles.Where(r => r.Name == "ClinicOwner").FirstOrDefault();
			var clinicOwnerRoleGreendo = new IdentityUserRole
			{
				RoleId = clinicOwnerRoleDbGreendo.Id
			};

			var greenDo = new User
			{
				UserName = "greendo@vet.com",
				Email = "greendo@vet.com",
				PasswordHash = new PasswordHasher().HashPassword("greendo@vet.com"),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			clinicOwners.Add(greenDo);
			context.Users.Add(greenDo);
			greenDo.Roles.Add(clinicOwnerRoleGreendo);

			var clinicOwnerRoleDbAmivet = context.Roles.Where(r => r.Name == "ClinicOwner").FirstOrDefault();
			var clinicOwnerRoleAmivet = new IdentityUserRole
			{
				RoleId = clinicOwnerRoleDbAmivet.Id
			};

			var amiVet = new User
			{
				UserName = "amivet@vet.com",
				Email = "amivet@vet.com",
				PasswordHash = new PasswordHasher().HashPassword("amivet@vet.com"),
				SecurityStamp = Guid.NewGuid().ToString()
			};

			clinicOwners.Add(amiVet);
			context.Users.Add(amiVet);
			amiVet.Roles.Add(clinicOwnerRoleAmivet);

			context.SaveChanges();

			// Users
			var users = new List<User>();

			for (int i = 1; i <= 20; i++)
			{
				var user = new User
				{
					UserName = $"user{i}@site.com",
					Email = $"user{i}@site.com",
					PasswordHash = new PasswordHasher().HashPassword($"user{i}@site.com"),
					SecurityStamp = Guid.NewGuid().ToString()
				};

				users.Add(user);
				context.Users.Add(user);
			}

			context.SaveChanges();

			// Clinics
			for (int i = 1; i <= 10; i++)
			{
				var owner = clinicOwners[i % clinicOwners.Count()];
				var clinic = new Clinic
				{
					Name = $"Some Clinic {i}",
					Information = $"Lorem Ipsum... {i}",
					Owner = owner,
				};

				context.Clinics.Add(clinic);
			}

			context.SaveChanges();

			// Pets
			var clinics = context.Clinics.ToList();
			for (int i = 1; i <= 30; i++)
			{
				var clinic = clinics[i % clinics.Count()];
				var owner = users[i % users.Count()];

				var pet = new Pet
				{
					Name = $"Pet {i}",
					Clinic = clinic,
					Owner = owner
				};

				context.Pets.Add(pet);
			}

			context.SaveChanges();
		}
	}
}

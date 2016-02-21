﻿namespace VetSystem.Services.Data
{
    using System;
    using System.Linq;
    using VetSystem.Data.Common.Repositories;
    using VetSystem.Data.Models;
    using VetSystem.Services.Data.Contracts;

    public class ClinicsService : IClinicsService
    {
        private readonly IDbRepository<Clinic> clinics;
        private readonly IDbRepository<Pet> pets;

        public ClinicsService(IDbRepository<Clinic> clinics, IDbRepository<Pet> pets)
        {
            this.clinics = clinics;
            this.pets = pets;
        }

        public IQueryable<Clinic> GetAll()
        {
            var clinics = this.clinics.All();
            return clinics;
        }

        public IQueryable<Clinic> GetById(int id)
        {
            return this.clinics.All().Where(x => x.Id == id);
        }
    }
}

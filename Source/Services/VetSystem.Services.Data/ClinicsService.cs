namespace VetSystem.Services.Data
{
    using System;
    using System.Linq;

    using VetSystem.Data.Common.Repositories;
    using VetSystem.Data.Models;
    using VetSystem.Services.Data.Contracts;
    using VetSystem.Services.Web;

    public class ClinicsService : IClinicsService
    {
        private readonly IDbRepository<Clinic> clinics;
        private readonly IDbRepository<Pet> pets;
        private readonly IIdentifierProvider identifierProvider;

        public ClinicsService(IDbRepository<Clinic> clinics, IDbRepository<Pet> pets, IIdentifierProvider identifierProvider)
        {
            this.clinics = clinics;
            this.pets = pets;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Clinic> GetAll()
        {
            var clinics = this.clinics.All();
            return clinics;
        }

        public IQueryable<Clinic> GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            return this.clinics.All().Where(x => x.Id == intId);
        }

        public IQueryable<Clinic> MostRated(int count)
        {
            return this.clinics.All()
                .OrderByDescending(c => c.Ratings.Average(x => x.Value))
                .ThenBy(c => c.Name)
                .Take(count);
        }

        public IQueryable<Clinic> TopPetsCount(int count)
        {
            return this.clinics.All()
                .OrderByDescending(c => c.Pets.Count())
                .ThenBy(c => c.Name)
                .Take(count);
        }
    }
}

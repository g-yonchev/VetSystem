namespace VetSystem.Services.Data
{
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
    }
}

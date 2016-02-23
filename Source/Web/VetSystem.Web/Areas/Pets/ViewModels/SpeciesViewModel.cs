namespace VetSystem.Web.Areas.Pets.ViewModels
{
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class SpeciesViewModel : IMapFrom<PetSpecies>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
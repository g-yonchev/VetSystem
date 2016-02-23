namespace VetSystem.Web.Areas.VetClinics.ViewModels
{
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class PetJoinToClinicViewModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
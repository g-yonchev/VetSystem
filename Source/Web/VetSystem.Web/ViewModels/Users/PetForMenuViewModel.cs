namespace VetSystem.Web.ViewModels.Users
{
    using VetSystem.Data.Models;
    using VetSystem.Web.Infrastructure.Mapping;

    public class PetForMenuViewModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }
    }
}
namespace VetSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using VetSystem.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        public int ClinicId { get; set; }

        public virtual Clinic Clinic { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Range(0,5)]
        public int Value { get; set; }
    }
}

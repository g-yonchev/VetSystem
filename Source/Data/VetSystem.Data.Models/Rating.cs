namespace VetSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using VetSystem.Common.Constants;
    using VetSystem.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        public int ClinicId { get; set; }

        public virtual Clinic Clinic { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Range(ValidationConstants.MinRatingValue, ValidationConstants.MaxRatingValue)]
        public int Value { get; set; }
    }
}

namespace VetSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        [Key]
        [ForeignKey("Pet")]
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        public byte[] Content { get; set; }

        public string OriginalName { get; set; }

        public string FileExtension { get; set; }

        public string UrlPath { get; set; }
    }
}

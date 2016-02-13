namespace VetSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using VetSystem.Data.Common.Models;

	public class Pet : BaseModel<int>
	{
		[Required]
		public string Name { get; set; }

		public string OwnerId { get; set; }

		public virtual User Owner { get; set; }

		public int? ClinicId { get; set; }

		public virtual Clinic Clinic { get; set; }
	}
}

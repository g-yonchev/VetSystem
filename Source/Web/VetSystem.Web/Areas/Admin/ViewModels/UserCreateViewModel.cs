namespace VetSystem.Web.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Clinic Owner?")]
        public bool IsClinicOwner { get; set; }
    }
}

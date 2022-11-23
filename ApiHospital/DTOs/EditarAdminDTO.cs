using System.ComponentModel.DataAnnotations;

namespace ApiHospital.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

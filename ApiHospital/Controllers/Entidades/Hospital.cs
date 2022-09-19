using System.ComponentModel.DataAnnotations;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String NombreHospital { get; set; }
    }
}

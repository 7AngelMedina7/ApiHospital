using System.ComponentModel.DataAnnotations;

namespace ApiHospital.Controllers.Entidades
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [MaxLength(100,ErrorMessage ="Introduce un Id Valido")]
        [Required(ErrorMessage ="El Id del Paciente es obligatorio")]
        public int HospitalId { get; set; }

        [Required(ErrorMessage ="El Nombre es obligatorio")]
        [DataType(DataType.Text, ErrorMessage ="El nombre debe de ser texto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="La edad es obligatoria")]
        [Range(0,100,ErrorMessage ="Introduce una edad valida")]
        public int Edad { get; set; }

        [Required(ErrorMessage ="El peso es Obligatorio")]
        public decimal peso { get; set; }
        
        [Required(ErrorMessage ="La estatura es Obligatoria")]
        public decimal estatura { get; set; }

    }
}

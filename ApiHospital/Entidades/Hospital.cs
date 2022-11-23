using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiHospital.Validaciones;
using Microsoft.AspNetCore.Authorization;

namespace ApiHospital.Controllers.Entidades
{
    public class Hospital
    {
        [Key]
        public int IdHospital { get; set; }
        [Required(ErrorMessage ="El Nombre del hospital es obligatorio")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Introduce un nombre valido")]
        [PrimeraLetraMayuscula]
        
        public string NombreHospital { get; set; }
        public List<Paciente> Pacientes { get; set; }




        //Se pueden añadir las validaciones dentro de las entidades
        //
        //
        //[NotMapped]
        //public int Menor { get; set; }
        //[NotMapped]
        //public int Mayor { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    //Para que se ejecuten debe de primero cumplirse con las reglas por Atributo Ejemplo: Range
        //    // Tomar a consideración que primero se ejecutaran las validaciones mappeadas en los atributos
        //    // y posteriormente las declaradas en la entidad
        //    if (!string.IsNullOrEmpty(NombreHospital))
        //    {
        //        var primeraLetra = NombreHospital[0].ToString();

        //        if (primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula",
        //                new String[] { nameof(NombreHospital) });
        //        }
        //    }

        //    if (Menor > Mayor)
        //    {
        //        yield return new ValidationResult("Este valor no puede ser mas grande que el campo Mayor",
        //            new String[] { nameof(Menor) });
        //    }
        //}
    }
}

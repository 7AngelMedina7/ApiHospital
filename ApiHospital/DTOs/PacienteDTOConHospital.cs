namespace ApiHospital.DTOs
{
    public class PacienteDTOConHospital: PacienteDTO
    {
        public List<GetHospitalDTO> Hospitales { get; set; }
    }
}

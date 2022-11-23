namespace ApiHospital.DTOs
{
    public class HospitalDTOConPacientes: GetHospitalDTO
    {
        public List<PacienteDTO> Pacientes { get;  set; }
    }
}

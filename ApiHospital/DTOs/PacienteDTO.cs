namespace ApiHospital.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public decimal peso { get; set; }

        public decimal estatura { get; set; }

        public List<EnfermedadDTO> EnfermedadDTO { get; set; }

    }
}

using ApiHospital.Controllers.Entidades;
using ApiHospital.DTOs;
using ApiHospital.Entidades;
using AutoMapper;

namespace ApiHospital.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        //BASADO EN LA PRESENTADA POR EL PROFESOR
        public AutoMapperProfiles()
        {
            CreateMap<HospitalDTO, Hospital>();
            CreateMap<Hospital, GetHospitalDTO>();
            CreateMap<Hospital, HospitalDTOConPacientes>()
                .ForMember(hospitalDTO => hospitalDTO.Pacientes, opciones => opciones.MapFrom(MapHospitalDTOPacientes));
            CreateMap<PacienteCreacionDTO, Paciente>()
                .ForMember(clase => clase.HospitalPaciente, opciones => opciones.MapFrom(MapHospitalPaciente));
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<Paciente, PacienteDTOConHospital>()
                .ForMember(pacienteDTO => pacienteDTO.Hospitales, opciones => opciones.MapFrom(MapPacienteDTOHospital));
            CreateMap<PacientePatchDTO, Paciente>().ReverseMap();
            CreateMap<EnfermedadCreacionDTO, Enfermedad>();
            CreateMap<Enfermedad, EnfermedadDTO>();
        }

        

        private List<PacienteDTO> MapHospitalDTOPacientes(Hospital hospital, GetHospitalDTO getHospitalDTO)
        {
            var result = new List<PacienteDTO>();

            if (hospital.HospitalPaciente == null) { return result; }

            foreach (var pacientes in hospital.HospitalPaciente)
            {
                result.Add(new PacienteDTO()
                {//idpaciente
                    Id = pacientes.PacienteId,
                    Nombre = pacientes.paciente.Nombre
                }) ;
            }

            return result;
        }

        private List<GetHospitalDTO> MapPacienteDTOHospital(Paciente paciente, PacienteDTO pacienteDTO)
        {
            var result = new List<GetHospitalDTO>();

            if (paciente.HospitalPaciente == null)
            {
                return result;
            }

            foreach (var hospitalPaciente in paciente.HospitalPaciente)
            {
                result.Add(new GetHospitalDTO()
                {
                    Id= hospitalPaciente.PacienteId,
                    Nombre = hospitalPaciente.paciente.Nombre
                });
            }

            return result;
        }

        private List<HospitalPaciente> MapHospitalPaciente(PacienteCreacionDTO pacienteCreacionDTO, Paciente paciente)
        {
            var resultado = new List<HospitalPaciente>();

            if (pacienteCreacionDTO.HospitalesIds == null) { return resultado; }
            foreach (var hospitalId in pacienteCreacionDTO.HospitalesIds)
            {
                resultado.Add(new HospitalPaciente() { HospitalId = hospitalId });
            }
            return resultado;
        }
    }
}
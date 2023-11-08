using AutoMapper;
using Core.DTO;
using Models;

namespace BLL.Mapper
{
	public class Profiles : Profile
	{
		public Profiles()
		{
			CreateMap<Persona, PersonaDTO>();
			CreateMap<DomicilioPorPersona, DomicilioPersonaDTO>();
			CreateMap<DomicilioPorDepartamento, DomicilioDTO>();
			CreateMap<DomicilioPorLocalidad, DomicilioDTO>();
			CreateMap<DomicilioPorBarrio, DomicilioDTO>();
			CreateMap<DomicilioPorDepartamentoLocalidad, DomicilioDTO>();
			CreateMap<DomicilioPorDepartamentoBarrio, DomicilioDTO>();
			CreateMap<DomicilioPorLocalidadBarrio, DomicilioDTO>();
			CreateMap<DomicilioPorDepartamentoLocalidadBarrio, DomicilioDTO>();
		}
	}
}

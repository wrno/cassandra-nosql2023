using AutoMapper;
using Core.DTO;
using Models;
using System.Xml.Serialization;

namespace Models.Mapper
{
	public class Profiles : Profile
	{
		public Profiles()
		{
			CreateMap<Persona, PersonaDTO>();

			CreateMap<DomicilioPorPersona, DomicilioPersonaDTO>()
				.ForMember(dest => dest.Ci, opt => opt.MapFrom(src => src.PersonaCi))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.PersonaNombre))
				.ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.PersonaApellido))
				.ForMember(dest => dest.Edad, opt => opt.MapFrom(src => src.PersonaEdad));

			CreateMap<DomicilioPorDepartamento, DomicilioDTO>();
			CreateMap<DomicilioPorLocalidad, DomicilioDTO>();
			CreateMap<DomicilioPorBarrio, DomicilioDTO>();
			CreateMap<DomicilioPorDepartamentoLocalidad, DomicilioDTO>();
			CreateMap<DomicilioPorDepartamentoBarrio, DomicilioDTO>();
			CreateMap<DomicilioPorLocalidadBarrio, DomicilioDTO>();
			CreateMap<DomicilioPorDepartamentoLocalidadBarrio, DomicilioDTO>();

			CreateMap<DomicilioPorPersona, DomicilioPorDepartamento>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<DomicilioPorPersona, DomicilioPorLocalidad>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<DomicilioPorPersona, DomicilioPorBarrio>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<DomicilioPorPersona, DomicilioPorDepartamentoLocalidad>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<DomicilioPorPersona, DomicilioPorDepartamentoBarrio>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<DomicilioPorPersona, DomicilioPorLocalidadBarrio>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<DomicilioPorPersona, DomicilioPorDepartamentoLocalidadBarrio>()
				.ForMember(dest => dest.Apartamento, opt => opt.MapFrom(src => src.Apartamento))
				.ForMember(dest => dest.Padron, opt => opt.MapFrom(src => src.Padron))
				.ForMember(dest => dest.Ruta, opt => opt.MapFrom(src => src.Ruta))
				.ForMember(dest => dest.Km, opt => opt.MapFrom(src => src.Km))
				.ForMember(dest => dest.Letra, opt => opt.MapFrom(src => src.Letra));

			CreateMap<NuevoDomicilioDTO, DomicilioDTO>();
		}
	}
}

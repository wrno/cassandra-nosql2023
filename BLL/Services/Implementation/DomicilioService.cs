using AutoMapper;
using Core.DTO;
using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
	public class DomicilioService : IDomicilioService
	{
		private readonly IMapper _mapper;
		private readonly IDomicilioRepository _domicilioRepository;
		private readonly IPersonaRepository _personaRepository;

		public DomicilioService(IMapper mapper, IDomicilioRepository domicilioRepository, IPersonaRepository personaRepository)
		{
			_mapper = mapper;
			_domicilioRepository = domicilioRepository;
			_personaRepository = personaRepository;
		}

		public async Task<DomicilioPersonaDTO> AgregarDomicilio(NuevoDomicilioDTO domicilio)
		{
			if (domicilio != null)
			{
				if (domicilio.Ci >= 10000000 && domicilio.Ci <= 99999999)
				{
					if (!string.IsNullOrEmpty(domicilio.Departamento))
					{
						if (!string.IsNullOrEmpty(domicilio.Localidad))
						{
							if (!string.IsNullOrEmpty(domicilio.Barrio))
							{
								if (!string.IsNullOrEmpty(domicilio.Calle))
								{
									Persona? persona = await _personaRepository.FindByIdentifier(domicilio.Ci);
									if (persona != null)
									{
										DomicilioPorPersona domicilioPorPersona = new()
										{
											FechaCreada = DateTimeOffset.UtcNow,
											PersonaCi = domicilio.Ci,
											PersonaNombre = persona.Nombre,
											PersonaApellido = persona.Apellido,
											PersonaEdad = persona.Edad,
											Departamento = domicilio.Departamento,
											Localidad = domicilio.Localidad,
											Barrio = domicilio.Barrio,
											Calle = domicilio.Calle,
											Nro = domicilio.Nro,
											Apartamento = domicilio.Apartamento ?? "",
											Padron = domicilio.Padron ?? default,
											Ruta = domicilio.Ruta ?? "",
											Km = domicilio.Km ?? default,
											Letra = domicilio.Letra ?? ""
										};

										return _mapper.Map<DomicilioPersonaDTO>(_domicilioRepository.Create(domicilioPorPersona));
									}
									else
									{
										throw new ArgumentException("No se ha registrado ninguna persona con cédula " + domicilio.Ci + ".");
									}
								}
								else
								{
									throw new ArgumentException("Debe ingresar una calle.");
								}
							}
							else
							{
								throw new ArgumentException("Debe ingresar un barrio.");
							}
						}
						else
						{
							throw new ArgumentException("Debe ingresar una localidad.");
						}
					}
					else
					{
						throw new ArgumentException("Debe ingresar un departamento.");
					}
				}
				else
				{
					throw new ArgumentException("Debe ingresar una cédula válida.");
				}
			}
			else
			{
				throw new ArgumentException("Debe especificar un domicilio.");
			}
		}

		public List<DomicilioPersonaDTO> ConsultarDomicilio(int ci, int? limit, ref byte[]? pagingState)
		{
			return _mapper.Map<List<DomicilioPersonaDTO>>(_domicilioRepository.GetAllDomiciliosByPersona(ci, limit, ref pagingState));
		}

		public async Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamento(string departamento)
		{
			if (departamento != null && departamento != "")
			{
				return _mapper.Map<List<DomicilioDTO>>(_domicilioRepository.GetAllDomiciliosPorDepartamento(departamento));
			}
			else
			{
				throw new ArgumentException("Debe especificar un departamento.");
			}
		}

        public async Task<List<DomicilioDTO>> ConsultarDomiciliosPorLocalidad(string localidad)
		{
            if (localidad != null && localidad != "")
            {
                return _mapper.Map<List<DomicilioDTO>>(_domicilioRepository.GetAllDomiciliosPorLocalidad(localidad));
            }
            else
            {
                throw new ArgumentException("Debe especificar una localidad.");
            }
        }

		public async Task<List<DomicilioDTO>> ConsultarDomiciliosPorBarrio(string barrio)
		{
            if (barrio != null && barrio != "")
            {
                return _mapper.Map<List<DomicilioDTO>>(_domicilioRepository.GetAllDomiciliosPorBarrio(barrio));
            }
            else
            {
                throw new ArgumentException("Debe especificar un barrio.");
            }
        }

		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamentoLocalidad(string departamento, string localidad)
		{
			throw new NotImplementedException();
		}

		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamentoBarrio(string departamento, string barrio)
		{
			throw new NotImplementedException();
		}

		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorLocalidadBarrio(string localidad, string barrio)
		{
			throw new NotImplementedException();
		}

		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamentoLocalidadBarrio(string departamento, string localidad, string barrio)
		{
			throw new NotImplementedException();
		}
	}
}

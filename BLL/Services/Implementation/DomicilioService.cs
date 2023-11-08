using AutoMapper;
using Core.DTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
	public class DomicilioService : IDomicilioService
	{
		private readonly IMapper _mapper;
		private readonly IDomicilioRepository _domicilioRepository;

		public DomicilioService(IMapper mapper, IDomicilioRepository domicilioRepository)
		{
			_mapper = mapper;
			_domicilioRepository = domicilioRepository;
		}

		public DomicilioPersonaDTO AgregarDomicilio(NuevoDomicilioDTO domicilio)
		{
			throw new NotImplementedException();
		}

		public Task<List<DomicilioPersonaDTO>> ConsultarDomicilio(int ci, int? skip, int? count)
		{
			throw new NotImplementedException();
		}

		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamento(string departamento)
		{
			throw new NotImplementedException();
		}
		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorLocalidad(string localidad)
		{
			throw new NotImplementedException();
		}

		public Task<List<DomicilioDTO>> ConsultarDomiciliosPorBarrio(string barrio)
		{
			throw new NotImplementedException();
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

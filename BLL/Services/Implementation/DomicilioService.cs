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
		private readonly IDomicilioRepository _domicilioRepository;

		public DomicilioService(IDomicilioRepository domicilioRepository)
		{
			_domicilioRepository = domicilioRepository;
		}

		public DomicilioPersonaDTO AgregarDomicilio(NuevoDomicilioDTO domicilio)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioPersonaDTO> ConsultarDomicilio(int ci, int? skip, int? count)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioDTO> ConsultarDomiciliosPorDepartamento(string departamento)
		{
			throw new NotImplementedException();
		}
		public List<DomicilioDTO> ConsultarDomiciliosPorLocalidad(string localidad)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioDTO> ConsultarDomiciliosPorBarrio(string barrio)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioDTO> ConsultarDomiciliosPorDepartamentoLocalidad(string departamento, string localidad)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioDTO> ConsultarDomiciliosPorDepartamentoBarrio(string departamento, string barrio)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioDTO> ConsultarDomiciliosPorLocalidadBarrio(string localidad, string barrio)
		{
			throw new NotImplementedException();
		}

		public List<DomicilioDTO> ConsultarDomiciliosPorDepartamentoLocalidadBarrio(string departamento, string localidad, string barrio)
		{
			throw new NotImplementedException();
		}
	}
}

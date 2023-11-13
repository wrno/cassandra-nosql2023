using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public interface IDomicilioService
	{
		Task<DomicilioPersonaDTO> AgregarDomicilio(NuevoDomicilioDTO domicilio);
		List<DomicilioPersonaDTO> ConsultarDomicilio(int ci, int? limit, ref byte[]? pagingState);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamento(string departamento);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorLocalidad(string localidad);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorBarrio(string barrio);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamentoLocalidad(string departamento, string localidad);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamentoBarrio(string departamento, string barrio);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorLocalidadBarrio(string localidad, string barrio);
		Task<List<DomicilioDTO>> ConsultarDomiciliosPorDepartamentoLocalidadBarrio(string departamento, string localidad, string barrio);
	}
}

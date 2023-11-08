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
		DomicilioPersonaDTO AgregarDomicilio(NuevoDomicilioDTO domicilio);
		List<DomicilioPersonaDTO> ConsultarDomicilio(int ci, int? skip, int? count);
		List<DomicilioDTO> ConsultarDomiciliosPorDepartamento(string departamento);
		List<DomicilioDTO> ConsultarDomiciliosPorLocalidad(string localidad);
		List<DomicilioDTO> ConsultarDomiciliosPorBarrio(string barrio);
		List<DomicilioDTO> ConsultarDomiciliosPorDepartamentoLocalidad(string departamento, string localidad);
		List<DomicilioDTO> ConsultarDomiciliosPorDepartamentoBarrio(string departamento, string barrio);
		List<DomicilioDTO> ConsultarDomiciliosPorLocalidadBarrio(string localidad, string barrio);
		List<DomicilioDTO> ConsultarDomiciliosPorDepartamentoLocalidadBarrio(string departamento, string localidad, string barrio);
	}
}

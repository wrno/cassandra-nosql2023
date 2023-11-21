using Core.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public interface IDomicilioRepository
	{
		DomicilioPorPersona Create(DomicilioPorPersona domicilio);
		List<DomicilioPorPersona> GetAllDomiciliosByPersona(int ci, int? limit, ref byte[]? pagingState);
        List<DomicilioPorBarrio> GetAllDomiciliosPorBarrio(string barrio);
        List<DomicilioPorDepartamento> GetAllDomiciliosPorDepartamento(string departamento);
        List<DomicilioPorLocalidad> GetAllDomiciliosPorLocalidad(string localidad);
        List<DomicilioPorDepartamentoLocalidad> GetAllDomiciliosPorDepartamentoLocalidad(string departamento, string? localidad);
        List<DomicilioPorDepartamentoBarrio> GetAllDomiciliosPorDepartamentoBarrio(string departamento, string? barrio);
        List<DomicilioPorLocalidadBarrio> GetAllDomiciliosPorLocalidadBarrio(string localidad, string? barrio);
        List<DomicilioPorDepartamentoLocalidadBarrio> GetAllDomiciliosPorDepartamentoLocalidadBarrio(string localidad, string barrio, string departamento);
    }
}

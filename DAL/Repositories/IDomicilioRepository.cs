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
	}
}

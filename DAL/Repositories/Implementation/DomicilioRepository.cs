using Cassandra.Data.Linq;
using DAL.Persistence;
using Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra.Mapping;
using System.Xml.Linq;
using Core.DTO;

namespace DAL.Repositories.Implementation
{
	public class DomicilioRepository : IDomicilioRepository
	{
		private readonly CassandraContext _ctx;
		private readonly AutoMapper.IMapper _mapper;

		public DomicilioRepository(CassandraContext ctx, AutoMapper.IMapper mapper)
		{
			_ctx = ctx;
			_mapper = mapper;
		}

		public DomicilioPorPersona Create(DomicilioPorPersona domicilio)
		{
			DomicilioPorDepartamento domicilioPorDepartamento = _mapper.Map<DomicilioPorDepartamento>(domicilio);
			DomicilioPorLocalidad domicilioPorLocalidad = _mapper.Map<DomicilioPorLocalidad>(domicilio);
			DomicilioPorBarrio domicilioPorBarrio = _mapper.Map<DomicilioPorBarrio>(domicilio);
			DomicilioPorDepartamentoLocalidad domicilioPorDepartamentoLocalidad = _mapper.Map<DomicilioPorDepartamentoLocalidad>(domicilio);
			DomicilioPorDepartamentoBarrio domicilioPorDepartamentoBarrio = _mapper.Map<DomicilioPorDepartamentoBarrio>(domicilio);
			DomicilioPorLocalidadBarrio domicilioPorLocalidadBarrio = _mapper.Map<DomicilioPorLocalidadBarrio>(domicilio);
			DomicilioPorDepartamentoLocalidadBarrio domicilioPorDepartamentoLocalidadBarrio = _mapper.Map<DomicilioPorDepartamentoLocalidadBarrio>(domicilio);

			_ctx.domiciliosporpersona.Insert(domicilio).Execute();
			_ctx.domiciliospordepartamento.Insert(domicilioPorDepartamento).Execute();
			_ctx.domiciliospordepartamento.Insert(domicilioPorDepartamento).Execute();
			_ctx.domiciliosporlocalidad.Insert(domicilioPorLocalidad).Execute();
			_ctx.domiciliosporbarrio.Insert(domicilioPorBarrio).Execute();
			_ctx.domiciliospordepartamentolocalidad.Insert(domicilioPorDepartamentoLocalidad).Execute();
			_ctx.domiciliospordepartamentobarrio.Insert(domicilioPorDepartamentoBarrio).Execute();
			_ctx.domiciliosporlocalidadbarrio.Insert(domicilioPorLocalidadBarrio).Execute();
			_ctx.domiciliospordepartamentolocalidadbarrio.Insert(domicilioPorDepartamentoLocalidadBarrio).Execute();

			return domicilio;
		}

		public List<DomicilioPorPersona> GetAllDomiciliosByPersona(int ci, int? limit, ref byte[]? pagingState)
		{
			CqlQuery<DomicilioPorPersona> query = _ctx.domiciliosporpersona
				.Where(p => p.PersonaCi.Equals(ci));

			if (limit.HasValue)
			{
				query = query.SetPageSize(limit.Value);

				if (pagingState != null)
				{
					query = query.SetPagingState(pagingState);
				}

				IPage<DomicilioPorPersona> page = query.ExecutePaged();

				pagingState = page.PagingState;

				return page.ToList();
			}
			else
			{
				return query.Execute().ToList();
			}
		}

        public List<DomicilioPorDepartamento> GetAllDomiciliosPorDepartamento(string departamento)
        {
            CqlQuery<DomicilioPorDepartamento> query = _ctx.domiciliospordepartamento.Where(p=>p.Departamento.Equals(departamento));
			return query.Execute().ToList();
        }
    }
}

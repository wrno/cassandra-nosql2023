using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
	public class DomicilioRepository : IDomicilioRepository
	{
		private readonly CassandraContext _ctx;

		public DomicilioRepository(CassandraContext ctx)
		{
			_ctx = ctx;
		}
	}
}

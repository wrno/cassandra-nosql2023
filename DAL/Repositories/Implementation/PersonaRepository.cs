using DAL.Persistence;
using Cassandra.Data.Linq;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly CassandraContext _ctx;

        public PersonaRepository(CassandraContext ctx)
        {
            _ctx = ctx;
        }

        public bool Exists(int ci)
        {
            if (_ctx.personas.Where(p => p.Ci.Equals(ci)).Count().Execute() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Persona Create(Persona persona)
        {
            if (persona != null)
            {
                if (!Exists(persona.Ci))
                {
                    _ctx.personas.Insert(persona).Execute();
                    return persona;
                }
                else
                {
                    throw new ArgumentException("Ya existe una persona registrada con la cédula " + persona.Ci + ".");
                }
            }
            else
            {
                throw new ArgumentException("Debe cargar los datos de la persona.");
            }
        }

		public async Task<Persona?> FindByIdentifier(int ci)
		{
            return await _ctx.personas.FirstOrDefault(p => p.Ci.Equals(ci)).ExecuteAsync();
		}
	}
}

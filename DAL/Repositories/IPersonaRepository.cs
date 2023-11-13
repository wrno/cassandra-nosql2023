using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPersonaRepository
    {
        bool Exists(int ci);
        Persona Create(Persona persona);
        Task<Persona?> FindByIdentifier(int ci);
    }
}

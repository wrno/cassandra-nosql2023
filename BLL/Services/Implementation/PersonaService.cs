using Core.DTO;
using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public bool Existe(int ci)
        {
            return _personaRepository.Exists(ci);
        }

        public PersonaDTO Agregar(PersonaDTO persona)
        {
            if (persona != null)
            {
                if (persona.Ci >= 10000000 && persona.Ci <= 99999999)
                {
                    if (persona.Nombre != null && persona.Nombre.Length > 0)
                    {
                        if (persona.Apellido != null && persona.Apellido.Length > 0)
                        {
                            if (persona.Edad >= 0)
                            {
                                Persona _persona = new()
                                {
                                    Ci = persona.Ci,
                                    Nombre = persona.Nombre,
                                    Apellido = persona.Apellido,
                                    Edad = persona.Edad
                                };

                                _persona = _personaRepository.Create(_persona);

                                return new()
                                {
                                    Ci = _persona.Ci,
                                    Nombre = _persona.Nombre,
                                    Apellido = _persona.Apellido,
                                    Edad = _persona.Edad
                                };
                            }
                            else
                            {
                                throw new ArgumentException("La edad (en años) debe ser un número entero mayor o igual a cero.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("El apellido no puede estar vacío.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("El nombre no puede estar vacío.");
                    }
                }
                else
                {
                    throw new ArgumentException("La cédula debe ser un número entero de 8 dígitos.");
                }
            }
            else
            {
                throw new ArgumentNullException("Debe cargar los datos de la persona.");
            }
        }
    }
}

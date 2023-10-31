using BLL.Services;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        // POST api/<PersonaController>
        [HttpPost]
        public ActionResult<PersonaDTO> AgregarPersona([Required] PersonaDTO persona)
        {
            if (persona != null)
            {
                if (!_personaService.Existe(persona.Ci))
                {
                    return StatusCode(StatusCodes.Status200OK, _personaService.Agregar(persona));
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "La persona ya existe.");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Los datos de la persona no pueden estar vacíos.");
            }
        }
    }
}

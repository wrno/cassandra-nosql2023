using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomicilioController : ControllerBase
    {
        // POST api/<DomicilioController>
        [HttpPost]
        public async Task<ActionResult<DomicilioPersonaDTO>> AgregarDomicilio([Required] NuevoDomicilioDTO domicilio)
        {
            return StatusCode(StatusCodes.Status402PaymentRequired, "No existe una persona con la cédula aportada como parámetro.");
        }

        // GET api/<DomicilioController>/5
        [HttpGet]
        public async Task<ActionResult<List<DomicilioPersonaDTO>>> ConsultarDomicilio(
            [Required]
            [Range(10000000, int.MaxValue, ErrorMessage = "Cédula inválida.")]
            int ci, 
            int? skip, 
            int? count)
        {
            return StatusCode(StatusCodes.Status402PaymentRequired, "No existe una persona con la cédula aportada como parámetro.");
        }
    }
}

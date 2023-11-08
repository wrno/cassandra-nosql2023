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

        // GET api/<DomicilioController>/persona/{ci}
        [HttpGet("persona/{ci}")]
        public async Task<ActionResult<List<DomicilioPersonaDTO>>> ConsultarDomicilio(
            [Required]
            [Range(10000000, int.MaxValue, ErrorMessage = "Cédula inválida.")]
            int ci, 
            int? skip, 
            int? count)
        {
            return StatusCode(StatusCodes.Status402PaymentRequired, "No existe una persona con la cédula aportada como parámetro.");
        }

        // GET api/<DomicilioController>
        [HttpGet]
        public async Task<ActionResult<List<DomicilioDTO>>> ObtenerDomiciliosPorCriterio(
            string? departamento,
            string? localidad,
            string? barrio)
        {
            if (!string.IsNullOrEmpty(departamento))
            {
                if (!string.IsNullOrEmpty(localidad))
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        // DomicilioPorDepartamentoLocalidadBarrio
                    }
                    else
                    {
                        // DomicilioPorDepartamentoLocalidad
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        // DomicilioPorDepartamentoBarrio
                    }
                    else
                    {
                        // DomicilioPorDepartamento
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(localidad))
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        // DomicilioPorLocalidadBarrio
                    }
                    else
                    {
                        // DomicilioPorLocalidad
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        // DomicilioPorBarrio
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "Debe especificar al menos un criterio.");
                    }
                }
            }
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
	}
}

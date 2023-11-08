using BLL.Services;
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
        private readonly IPersonaService _personaService;
        private readonly IDomicilioService _domicilioService;

        public DomicilioController(IPersonaService personaService, IDomicilioService domicilioService)
        {
            _personaService = personaService;
            _domicilioService = domicilioService;
        }

        // POST api/<DomicilioController>
        [HttpPost]
        public ActionResult<DomicilioPersonaDTO> AgregarDomicilio([Required] NuevoDomicilioDTO domicilio)
        {
            if (_personaService.Existe(domicilio.Ci))
            {
                return _domicilioService.AgregarDomicilio(domicilio);
            }
            else
			{
				return StatusCode(StatusCodes.Status402PaymentRequired, "No existe una persona con la cédula aportada como parámetro.");
			}
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
            if (_personaService.Existe(ci))
            {
                return await _domicilioService.ConsultarDomicilio(ci, skip, count);
            }
            else
			{
				return StatusCode(StatusCodes.Status402PaymentRequired, "No existe una persona con la cédula aportada como parámetro.");
			}
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
                        return await _domicilioService.ConsultarDomiciliosPorDepartamentoLocalidadBarrio(departamento, localidad, barrio);
                    }
                    else
                    {
                        return await _domicilioService.ConsultarDomiciliosPorDepartamentoLocalidad(departamento, localidad);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        return await _domicilioService.ConsultarDomiciliosPorDepartamentoBarrio(departamento, barrio);
                    }
                    else
                    {
                        return await _domicilioService.ConsultarDomiciliosPorDepartamento(departamento);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(localidad))
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        return await _domicilioService.ConsultarDomiciliosPorLocalidadBarrio(localidad, barrio);
                    }
                    else
                    {
                        return await _domicilioService.ConsultarDomiciliosPorLocalidad(localidad);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(barrio))
                    {
                        // DomicilioPorBarrio
                        return await _domicilioService.ConsultarDomiciliosPorBarrio(barrio);
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

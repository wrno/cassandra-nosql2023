using BLL.Services;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<ActionResult<DomicilioPersonaDTO>> AgregarDomicilio([Required] NuevoDomicilioDTO domicilio)
        {
            if (_personaService.Existe(domicilio.Ci))
            {
                return StatusCode(StatusCodes.Status200OK, await _domicilioService.AgregarDomicilio(domicilio));
            }
            else
			{
				return StatusCode(StatusCodes.Status402PaymentRequired, "No existe una persona con la cédula aportada como parámetro.");
			}
        }

        // GET api/<DomicilioController>/persona/{ci}
        [HttpGet("persona/{ci}")]
        public ActionResult<List<DomicilioPersonaDTO>> ConsultarDomicilio(
            [Required]
            [Range(10000000, 99999999, ErrorMessage = "Cédula inválida.")]
            int ci,
			int? limit)
        {
            if (_personaService.Existe(ci))
            {
                byte[]? pagingState = null;
                string? pagingStateString = Request.Headers["X-PagingState"].FirstOrDefault();

				if (pagingStateString != null)
				{
                    int NumberChars = pagingStateString.Length;
					pagingState = new byte[NumberChars / 2];
                    for (int i = 0; i < NumberChars; i += 2)
                    {
                        pagingState[i / 2] = Convert.ToByte(pagingStateString.Substring(i, 2), 16);
                    }
				}

				List<DomicilioPersonaDTO> domicilios = _domicilioService.ConsultarDomicilio(ci, limit, ref pagingState);

                if (pagingState != null)
				{
                    StringBuilder stringBuilder = new StringBuilder(pagingState.Length * 2);
                    foreach(byte b in pagingState)
                    {
                        stringBuilder.AppendFormat("{0:x2}", b);
                    }
					Response.Headers.Add("X-PagingState", stringBuilder.ToString());
                }

				return StatusCode(StatusCodes.Status200OK, domicilios);
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
        }
	}
}

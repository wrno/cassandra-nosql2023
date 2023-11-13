using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
	public class DomicilioDTO
	{
		public required string Departamento { get; set; }
		public required string Localidad { get; set; }
		public required string Barrio { get; set; }
		public required string Calle { get; set; }
		public required int Nro { get; set; }
		public string? Apartamento { get; set; }
		public int? Padron { get; set; }
		public string? Ruta { get; set; }
		public float? Km { get; set; }
		public string? Letra { get; set; }
	}
}

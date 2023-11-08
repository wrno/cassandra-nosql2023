using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
	public class DomicilioDTO
	{
		public string Departamento { get; set; }
		public string Localidad { get; set; }
		public string Barrio { get; set; }
		public string Calle { get; set; }
		public int Nro { get; set; }
		public int? Apartamento { get; set; }
		public int? Padron { get; set; }
		public string? Ruta { get; set; }
		public float? Km { get; set; }
		public string? Letra { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class DomicilioPersonaDTO
    {
        public required DateTimeOffset FechaCreada { get; set; }
        public required int Ci { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required int Edad { get; set; }
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

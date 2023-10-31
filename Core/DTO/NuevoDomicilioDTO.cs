using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class NuevoDomicilioDTO
    {
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "Cédula inválida.")]
        public required int Ci { get; set; }

        [Required]
        public required string Departamento { get; set; }

        [Required]
        public required string Localidad { get; set; }

        [Required]
        public required string Barrio { get; set; }

        [Required]
        public required string Calle { get; set; }

        [Required(ErrorMessage = "El número de calle es obligatorio. Si no tiene número de calle, ingrese cero.")]
        [Range(0, int.MaxValue, ErrorMessage = "El número de calle debe ser mayor o igual a cero.")]
        public required int Nro { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El número de apartamento debe ser mayor o igual a cero.")]
        public int? Apartamento { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El padrón debe ser mayor o igual a cero.")]
        public int? Padron { get; set; }
        public string? Ruta { get; set; }

        [Range(0, int.MaxValue - 1, ErrorMessage = "El kilómetro debe ser mayor o igual a cero.")]
        public float? Km { get; set; }
        public string? Letra { get; set; }
    }
}

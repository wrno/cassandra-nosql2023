using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class PersonaDTO
    {
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "Cédula inválida.")]
        public required int Ci { get; set; }

        [Required]
        public required string Nombre { get; set; }

        [Required]
        public required string Apellido { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La edad (en años) debe ser un número entero mayor o igual a cero.")]
        public required int Edad { get; set; }
    }
}

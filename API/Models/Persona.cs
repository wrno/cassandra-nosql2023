using Cassandra.Mapping.Attributes;

namespace API.Models
{
    [Table()]
    public class Persona
    {
        [PartitionKey]
        public string Ci { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
    }
}

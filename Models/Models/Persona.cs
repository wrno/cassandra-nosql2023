using Cassandra.Mapping.Attributes;

namespace Models
{
    [Table("personas")]
    public class Persona
    {
        [PartitionKey]
        [Column("ci")]
        public required int Ci { get; set; }

        [Column("nombre")]
        public required string Nombre { get; set; }

        [Column("apellido")]
        public required string Apellido { get; set; }

        [Column("edad")]
        public required int Edad { get; set; }
    }
}

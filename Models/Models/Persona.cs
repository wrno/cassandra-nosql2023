using Cassandra.Mapping.Attributes;

namespace Models
{
    [Table("personas")]
    public class Persona
    {
        [PartitionKey]
        [Column("ci")]
        public int Ci { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellido")]
        public string Apellido { get; set; }

        [Column("edad")]
        public int Edad { get; set; }
    }
}

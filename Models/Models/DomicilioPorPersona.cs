using Cassandra.Mapping.Attributes;

namespace Models
{
    [Table("domiciliosporpersona")]
    public class DomicilioPorPersona
    {
        [SecondaryIndex]
        [Column("fechacreada")]
        public DateTimeOffset FechaCreada { get; set; }

        [PartitionKey]
        [Column("ci")]
        public int PersonaCi { get; set; }

        [ClusteringKey(1)]
        [Column("departamento")]
        public string Departamento { get; set; }

        [ClusteringKey(2)]
        [Column("localidad")]
        public string Localidad { get; set; }

        [ClusteringKey(3)]
        [Column("barrio")]
        public string Barrio { get; set; }

        [ClusteringKey(4)]
        [Column("calle")]
        public string Calle { get; set; }

        [ClusteringKey(5)]
        [Column("nro")]
        public int Nro { get; set; }

        [ClusteringKey(6)]
        [Column("apartamento")]
        public int Apartamento { get; set; }

        [ClusteringKey(7)]
        [Column("padron")]
        public int Padron { get; set; }

        [ClusteringKey(8)]
        [Column("ruta")]
        public string Ruta { get; set; }

        [ClusteringKey(9)]
        [Column("km")]
        public float Km { get; set; }

        [ClusteringKey(10)]
        [Column("letra")]
        public string Letra { get; set; }

        [StaticColumn]
        [Column("nombre")]
        public string PersonaNombre { get; set; }

        [StaticColumn]
        [Column("apellido")]
        public string PersonaApellido { get; set; }

        [StaticColumn]
        [Column("edad")]
        public string PersonaEdad { get; set; }
    }
}

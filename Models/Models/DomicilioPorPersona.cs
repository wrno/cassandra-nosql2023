using Cassandra.Mapping;
using Cassandra.Mapping.Attributes;

namespace Models
{
    [Table("domiciliosporpersona")]
    public class DomicilioPorPersona
    {
        [PartitionKey]
        [Column("ci")]
        public required int PersonaCi { get; set; }

		[ClusteringKey(1, SortOrder.Descending)]
		[Column("fechacreada")]
		public required DateTimeOffset FechaCreada { get; set; }

		[ClusteringKey(2, SortOrder.Ascending)]
        [Column("departamento")]
        public required string Departamento { get; set; }

        [ClusteringKey(3, SortOrder.Ascending)]
        [Column("localidad")]
        public required string Localidad { get; set; }

        [ClusteringKey(4, SortOrder.Ascending)]
        [Column("barrio")]
        public required string Barrio { get; set; }

        [ClusteringKey(5, SortOrder.Ascending)]
        [Column("calle")]
        public required string Calle { get; set; }

        [ClusteringKey(6, SortOrder.Ascending)]
        [Column("nro")]
        public required int Nro { get; set; }

        [ClusteringKey(7, SortOrder.Ascending)]
        [Column("apartamento")]
        public required string Apartamento { get; set; }

        [ClusteringKey(8, SortOrder.Ascending)]
        [Column("padron")]
        public required int Padron { get; set; }

        [ClusteringKey(9, SortOrder.Ascending)]
        [Column("ruta")]
        public required string Ruta { get; set; }

        [ClusteringKey(10, SortOrder.Ascending)]
        [Column("km")]
        public required float Km { get; set; }

        [ClusteringKey(11, SortOrder.Ascending)]
        [Column("letra")]
        public required string Letra { get; set; }

		[StaticColumn]
        [Column("nombre")]
        public required string PersonaNombre { get; set; }

        [StaticColumn]
        [Column("apellido")]
        public required string PersonaApellido { get; set; }

        [StaticColumn]
        [Column("edad")]
        public required int PersonaEdad { get; set; }
    }
}

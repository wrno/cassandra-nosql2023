using Cassandra.Mapping.Attributes;

namespace Models
{
	[Table("domiciliospordepartamentolocalidadbarrio")]
	public class DomicilioPorDepartamentoLocalidadBarrio
	{
		[PartitionKey(1)]
		[Column("departamento")]
		public required string Departamento { get; set; }

		[PartitionKey(2)]
		[Column("localidad")]
		public required string Localidad { get; set; }

		[PartitionKey(3)]
		[Column("barrio")]
		public required string Barrio { get; set; }

		[ClusteringKey(1)]
		[Column("calle")]
		public required string Calle { get; set; }

		[ClusteringKey(2)]
		[Column("nro")]
		public required int Nro { get; set; }

		[ClusteringKey(3)]
		[Column("apartamento")]
		public required string Apartamento { get; set; }

		[ClusteringKey(4)]
		[Column("padron")]
		public required int Padron { get; set; }

		[ClusteringKey(5)]
		[Column("ruta")]
		public required string Ruta { get; set; }

		[ClusteringKey(6)]
		[Column("km")]
		public required float Km { get; set; }

		[ClusteringKey(7)]
		[Column("letra")]
		public required string Letra { get; set; }
	}
}

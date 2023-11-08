using Cassandra.Mapping.Attributes;

namespace Models
{
	[Table("domiciliospordepartamentobarrio")]
	public class DomicilioPorDepartamentoBarrio
	{
		[PartitionKey(1)]
		[Column("departamento")]
		public string Departamento { get; set; }

		[PartitionKey(2)]
		[Column("barrio")]
		public string Barrio { get; set; }

		[ClusteringKey(1)]
		[Column("localidad")]
		public string Localidad { get; set; }

		[ClusteringKey(2)]
		[Column("calle")]
		public string Calle { get; set; }

		[ClusteringKey(3)]
		[Column("nro")]
		public int Nro { get; set; }

		[ClusteringKey(4)]
		[Column("apartamento")]
		public int Apartamento { get; set; }

		[ClusteringKey(5)]
		[Column("padron")]
		public int Padron { get; set; }

		[ClusteringKey(6)]
		[Column("ruta")]
		public string Ruta { get; set; }

		[ClusteringKey(7)]
		[Column("km")]
		public float Km { get; set; }

		[ClusteringKey(8)]
		[Column("letra")]
		public string Letra { get; set; }
	}
}

using Cassandra.Mapping.Attributes;

namespace Models
{
    [Table("domiciliosporbarrio")]
    public class DomicilioPorBarrio
    {
        [PartitionKey(1)]
        public string Departamento { get; set; }

        [PartitionKey(2)]
        public string Localidad { get; set; }

        [PartitionKey(3)]
        public string Barrio { get; set; }

        [ClusteringKey(1)]
        public string Calle { get; set; }

        [ClusteringKey(2)]
        public int Nro { get; set; }

        [ClusteringKey(3)]
        public int? Apartamento { get; set; }

        [ClusteringKey(4)]
        public int? Padron { get; set; }

        [ClusteringKey(5)]
        public string? Ruta { get; set; }

        [ClusteringKey(6)]
        public float? Km { get; set; }

        [ClusteringKey(7)]
        public string? Letra { get; set; }
    }
}

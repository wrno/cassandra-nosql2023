using Cassandra.Mapping.Attributes;

namespace API.Models
{
    [Table]
    public class DomicilioPorPersona
    {
        [PartitionKey]
        public string PersonaCi { get; set; }

        [ClusteringKey(1)]
        public string Departamento { get; set; }

        [ClusteringKey(2)]
        public string Localidad { get; set; }

        [ClusteringKey(3)]
        public string Barrio { get; set; }

        [ClusteringKey(4)]
        public string Calle { get; set; }

        [ClusteringKey(5)]
        public int Nro { get; set; }

        [ClusteringKey(6)]
        public int Apartamento { get; set; }

        [ClusteringKey(7)]
        public int Padron { get; set; }

        [ClusteringKey(8)]
        public string Ruta { get; set; }

        [ClusteringKey(9)]
        public float Km { get; set; }

        [ClusteringKey(10)]
        public string Letra { get; set; }

        [StaticColumn]
        public string PersonaNombre { get; set; }

        [StaticColumn]
        public string PersonaApellido { get; set; }

        [StaticColumn]
        public string PersonaEdad { get; set; }
    }
}

using Cassandra.Mapping.Attributes;

namespace API.Models
{
    [Table]
    public class DomicilioPorDepartamento
    {
        /*
         * OPCIONAL: Definir una clave de partición con bucketing si se piensa paginar.
         * Ej.: En 2011 se contaron cerca de medio millón de hogares solo en Montevideo, mientras
         * en Flores apenas se contaron menos de 9.000 hogares.
        */

        [PartitionKey]
        public string Departamento { get; set; }

        [ClusteringKey(1)]
        public string Localidad { get; set; }

        [ClusteringKey(2)]
        public string Barrio { get; set; }

        [ClusteringKey(3)]
        public string Calle { get; set; }

        [ClusteringKey(4)]
        public int Nro { get; set; }

        [ClusteringKey(5)]
        public int Apartamento { get; set; }

        [ClusteringKey(6)]
        public int Padron { get; set; }

        [ClusteringKey(7)]
        public string Ruta { get; set; }

        [ClusteringKey(8)]
        public float Km { get; set; }

        [ClusteringKey(9)]
        public string Letra { get; set; }
    }
}

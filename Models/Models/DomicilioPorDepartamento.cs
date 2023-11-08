﻿using Cassandra.Mapping.Attributes;

namespace Models
{
    [Table("domiciliospordepartamento")]
    public class DomicilioPorDepartamento
    {
        /*
         * OPCIONAL: Definir una clave de partición con bucketing si se piensa paginar.
         * Ej.: En 2011 se contaron cerca de medio millón de hogares solo en Montevideo, mientras
         * en Flores apenas se contaron menos de 9.000 hogares.
        */

        [PartitionKey(1)]
        [Column("departamento")]
        public string Departamento { get; set; }

        [ClusteringKey(1)]
        [Column("localidad")]
        public string Localidad { get; set; }

        [ClusteringKey(2)]
        [Column("barrio")]
        public string Barrio { get; set; }

        [ClusteringKey(3)]
        [Column("calle")]
        public string Calle { get; set; }

        [ClusteringKey(4)]
        [Column("nro")]
        public int Nro { get; set; }

        [ClusteringKey(5)]
        [Column("apartamento")]
        public int? Apartamento { get; set; }

        [ClusteringKey(6)]
        [Column("padron")]
        public int? Padron { get; set; }

        [ClusteringKey(7)]
        [Column("ruta")]
        public string? Ruta { get; set; }

        [ClusteringKey(8)]
        [Column("km")]
        public float? Km { get; set; }

        [ClusteringKey(9)]
        [Column("letra")]
        public string? Letra { get; set; }
    }
}

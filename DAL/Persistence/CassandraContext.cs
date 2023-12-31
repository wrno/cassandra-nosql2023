﻿using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using Cassandra.Mapping.Attributes;
using Core.Enums;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class CassandraContext
    {
        private readonly IConfiguration _configuration;
        private readonly Cluster _cluster;
        private readonly ISession _session;

        // Tablas
        public readonly Table<Persona> personas;
        public readonly Table<DomicilioPorPersona> domiciliosporpersona;
        public readonly Table<DomicilioPorDepartamento> domiciliospordepartamento;
        public readonly Table<DomicilioPorLocalidad> domiciliosporlocalidad;
        public readonly Table<DomicilioPorBarrio> domiciliosporbarrio;
        public readonly Table<DomicilioPorDepartamentoLocalidad> domiciliospordepartamentolocalidad;
        public readonly Table<DomicilioPorDepartamentoBarrio> domiciliospordepartamentobarrio;
        public readonly Table<DomicilioPorLocalidadBarrio> domiciliosporlocalidadbarrio;
        public readonly Table<DomicilioPorDepartamentoLocalidadBarrio> domiciliospordepartamentolocalidadbarrio;

        public CassandraContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? keyspace = _configuration.GetSection("AppSettings:Cassandra:Keyspace").Value;

            //   ______________________________
            //  |                              |
            //  |   CONEXIÓN A BASE DE DATOS   |
            //  |          **INICIO**          |
            //  |______________________________|
            //

            string? enumDocker = Enum.GetName(typeof(Deployment), Deployment.Docker);
			if (enumDocker != null && enumDocker.Equals(_configuration.GetSection("AppSettings:Cassandra:Deployment").Value))
            {
                // SE CONECTA SEGÚN CONFIGURACIÓN DE DOCKER:
                string? username = _configuration.GetSection("AppSettings:Cassandra:Username").Value;
                string? password = _configuration.GetSection("AppSettings:Cassandra:Password").Value;
                string? contactPoint = _configuration.GetSection("AppSettings:Cassandra:ContactPoint").Value;
                string? portString = _configuration.GetSection("AppSettings:Cassandra:Port").Value;
				_ = int.TryParse(portString, out int port);

                _cluster = Cluster.Builder()
                    .WithCredentials(username, password)
                    .AddContactPoint(contactPoint)
                    .WithPort(port)
                    .WithDefaultKeyspace(keyspace)
                    .Build();

                _session = _cluster.ConnectAndCreateDefaultKeyspaceIfNotExists();
            }
            else
            {
				// SE CONECTA A DATASTAX ASTRA DB:
				string? bundle = _configuration.GetSection("AppSettings:Cassandra:BundlePath").Value;
				string? client = _configuration.GetSection("AppSettings:Cassandra:ClientId").Value;
				string? secret = _configuration.GetSection("AppSettings:Cassandra:ClientSecret").Value;

				_cluster = Cluster.Builder()
					.WithCloudSecureConnectionBundle(bundle)
					.WithCredentials(client, secret)
					.WithDefaultKeyspace(keyspace)
					.Build();

				_session = _cluster.Connect();
			}

			//   ______________________________
			//  |                              |
			//  |   CONEXIÓN A BASE DE DATOS   |
			//  |           **FIN**            |
			//  |______________________________|
			//

			personas = new(_session);
            domiciliosporpersona = new(_session);
            domiciliospordepartamento = new(_session);
            domiciliosporlocalidad = new(_session);
            domiciliosporbarrio = new(_session);
            domiciliospordepartamentolocalidad = new(_session);
            domiciliospordepartamentobarrio = new(_session);
            domiciliosporlocalidadbarrio = new(_session);
            domiciliospordepartamentolocalidadbarrio = new(_session);

            CrearModelos();
        }

        private void CrearModelos()
        {
            personas.CreateIfNotExists();
            domiciliosporpersona.CreateIfNotExists();
            domiciliospordepartamento.CreateIfNotExists();
            domiciliosporlocalidad.CreateIfNotExists();
            domiciliosporbarrio.CreateIfNotExists();
            domiciliospordepartamentolocalidad.CreateIfNotExists();
            domiciliospordepartamentobarrio.CreateIfNotExists();
            domiciliosporlocalidadbarrio.CreateIfNotExists();
            domiciliospordepartamentolocalidadbarrio.CreateIfNotExists();
        }
    }
}

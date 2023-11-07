# Laboratorio NoSQL: API de domicilios en Cassandra (cassandra-nosql2023)
**Laboratorio 2 de Taller de Bases de Datos NoSQL 2023 utilizando Apache Cassandra.** <br>
El repositorio contiene una solución de .NET cuyo proyecto principal es una API para almacenar en y consultar domicilios desde una base de datos Apache Cassandra.

Tabla de contenidos
-------------------
1. [Grupo](#grupo)
2. [Herramientas utilizadas](#herramientas-utilizadas)
3. [¿Por qué Cassandra?](#por-qué-cassandra)
4. [Modelado de datos](#modelado-de-datos)
   1. [personas](#personas)
   2. [domiciliosporpersona](#domiciliosporpersona)
   3. [domiciliospordepartamento](#domiciliospordepartamento)
   4. [domiciliosporlocalidad](#domiciliosporlocalidad)
   5. [domiciliosporbarrio](#domiciliosporbarrio)
   6. [domiciliospordepartamentolocalidad](#domiciliospordepartamentolocalidad)
   7. [domiciliospordepartamentobarrio](#domiciliospordepartamentobarrio)
   8. [domiciliosporlocalidadbarrio](#domiciliosporlocalidadbarrio)
   9. [domiciliospordepartamentolocalidadbarrio](#domiciliospordepartamentolocalidadbarrio)
5. [Instalar Cassandra con Docker en Windows](#instalar-cassandra-con-docker-en-windows)
6. [Configurar la aplicación](#configurar-la-aplicación)

Grupo
-----
- Acosta, Federico
- Collazo, Bruno
- Grasso, Sebastián

Herramientas utilizadas
-----------------------
- La solución fue desarrollada en **.NET** usando **C#** como lenguaje de programación.
- Los datos se almacenan en una base de datos **Apache Cassandra**.
- Tanto la base de datos como el sistema se despliegan utilizando **Docker**.
- Para la conexión con la base de datos Apache Cassandra desde nuestra aplicación desarrollada en C#, se utiliza el driver **CassandraCSharpDriver** desarrollado por DataStax.

¿Por qué Cassandra?
-------------------
En Apache Cassandra, además de ofrecer gran velocidad de respuesta —sobre todo— a operaciones de lectura y teóricamente 100% de *uptime*, el modelado de datos es *query-driven*: esto significa que las tablas a generar van a estar definidas por las consultas proyectadas, no al revés. </br>
En esta realidad específica, tenemos las siguientes consultas definidas:
- direcciones por persona,
- direcciones por departamento,
- direcciones por localidad,
- direcciones por barrio,
- direccones por departamento y localidad,
- direciones por departamento y barrio,
- direcciones por localidad y barrio y
- direcciones por departamento, localidad y barrio.

Sabiendo que estas son las únicas consultas que se pueden realizar, que en todos los casos se puede definir el o los filtros como clave de partición ya que no son datos editables y no se le pueden agregar filtros extra que puedan enlentecer las consultas, Cassandra parece ser un buen candidato para almacenar nuestros datos.

Modelado de datos
-----------------
Se debe generar una tabla por cada consulta que definimos en el anterior. De esta forma, se generan las siguientes tablas en Apache Cassandra:

### personas
| Columna  | Tipo | Índice |
|----------|------|:------:|
| ci       | int  |  **K** |
| nombre   | text |        |
| apellido | text |        |
| edad     | int  |        |

### domiciliosporpersona
| Columna      | Tipo      | Índice  |
|--------------|-----------|:-------:|
| ci           | int       |  **K**  |
| departamento | text      |  **C↑** |
| localidad    | text      |  **C↑** |
| barrio       | text      |  **C↑** |
| calle        | text      |  **C↑** |
| nro          | int       |  **C↑** |
| apartamento  | int       |  **C↑** |
| padron       | int       |  **C↑** |
| ruta         | text      |  **C↑** |
| km           | float     |  **C↑** |
| letra        | text      |  **C↑** |
| nombre       | text      |  **S**  |
| apellido     | text      |  **S**  |
| edad         | int       |  **S**  |
| fechacreada  | timestamp | **IDX** |

### domiciliospordepartamento
| Columna      | Tipo      | Índice  |
|--------------|-----------|:-------:|
| ci           | int       |  **K**  |
| departamento | text      |  **C↑** |
| localidad    | text      |  **C↑** |
| barrio       | text      |  **C↑** |
| calle        | text      |  **C↑** |
| nro          | int       |  **C↑** |
| apartamento  | int       |  **C↑** |
| padron       | int       |  **C↑** |
| ruta         | text      |  **C↑** |
| km           | float     |  **C↑** |
| letra        | text      |  **C↑** |
| nombre       | text      |  **S**  |
| apellido     | text      |  **S**  |
| edad         | int       |  **S**  |
| fechacreada  | timestamp | **IDX** |

### domiciliosporlocalidad
| Columna      | Tipo  | Índice |
|--------------|-------|:------:|
| localidad    | text  |  **K** |
| departamento | text  | **C↑** |
| barrio       | text  | **C↑** |
| calle        | text  | **C↑** |
| nro          | int   | **C↑** |
| apartamento  | int   | **C↑** |
| padron       | int   | **C↑** |
| ruta         | text  | **C↑** |
| km           | float | **C↑** |
| letra        | text  | **C↑** |

### domiciliosporbarrio
| Columna      | Tipo  | Índice |
|--------------|-------|:------:|
| barrio       | text  |  **K** |
| departamento | text  | **C↑** |
| localidad    | text  |  **K** |
| calle        | text  | **C↑** |
| nro          | int   | **C↑** |
| apartamento  | int   | **C↑** |
| padron       | int   | **C↑** |
| ruta         | text  | **C↑** |
| km           | float | **C↑** |
| letra        | text  | **C↑** |

### domiciliospordepartamentolocalidad
| Columna      | Tipo  | Índice |
|--------------|-------|:------:|
| departamento | text  |  **K** |
| localidad    | text  |  **K** |
| barrio       | text  | **C↑** |
| calle        | text  | **C↑** |
| nro          | int   | **C↑** |
| apartamento  | int   | **C↑** |
| padron       | int   | **C↑** |
| ruta         | text  | **C↑** |
| km           | float | **C↑** |
| letra        | text  | **C↑** |

### domiciliospordepartamentobarrio
| Columna      | Tipo  | Índice |
|--------------|-------|:------:|
| departamento | text  |  **K** |
| barrio       | text  |  **K** |
| localidad    | text  | **C↑** |
| calle        | text  | **C↑** |
| nro          | int   | **C↑** |
| apartamento  | int   | **C↑** |
| padron       | int   | **C↑** |
| ruta         | text  | **C↑** |
| km           | float | **C↑** |
| letra        | text  | **C↑** |

### domiciliosporlocalidadbarrio
| Columna      | Tipo  | Índice |
|--------------|-------|:------:|
| localidad    | text  |  **K** |
| barrio       | text  |  **K** |
| departamento | text  | **C↑** |
| calle        | text  | **C↑** |
| nro          | int   | **C↑** |
| apartamento  | int   | **C↑** |
| padron       | int   | **C↑** |
| ruta         | text  | **C↑** |
| km           | float | **C↑** |
| letra        | text  | **C↑** |

### domiciliospordepartamentolocalidadbarrio
| Columna      | Tipo  | Índice |
|--------------|-------|:------:|
| departamento | text  |  **K** |
| localidad    | text  |  **K** |
| barrio       | text  |  **K** |
| calle        | text  | **C↑** |
| nro          | int   | **C↑** |
| apartamento  | int   | **C↑** |
| padron       | int   | **C↑** |
| ruta         | text  | **C↑** |
| km           | float | **C↑** |
| letra        | text  | **C↑** |

Instalar Cassandra con Docker en Windows
----------------------------------------
Para poder usar Cassandra, debe asegurarse de tener instalado **Java SE 8 u OpenJDK 8**.

Debe instalar **WSL 2** con **Ubuntu**:
- Ejecute PowerShell como administrador.
- Ejecute el siguiente comando: `wsl --install -d ubuntu`.
- Reinicie la computadora y ejecute Ubuntu si no lo hace automáticamente.
- Configure su usuario de Ubuntu.
- Actualice toda aplicación de Ubuntu y repositorios a la última versión usando `sudo apt update` y luego `sudo apt upgrade`.

Ahora puede descargar e instalar **Docker Desktop** desde la [página oficial de Docker](https://www.docker.com/products/docker-desktop/).

Para instalar la imagen de Cassandra en Docker, tiene dos opciones:
1. **Con Docker Desktop**
    - En el buscador, escriba **"Cassandra"**.
    - Seleccione el primer resultado.
    - Haga clic en **Pull**.
    - Vaya al menú **Images**.
    - Haga clic en
           <picture>
               <img alt="Run" title="Run" src="https://github.com/wrno/cassandra-nosql2023/assets/102438410/16b60595-f383-4068-9770-8d78952d4774">
           </picture>
      en la imagen llamada *cassandra*.
    - Definir nombre y mapear el puerto 9042 del contenedor. En nuestro caso, usamos el nombre *cass_cluster* y mapeamos el puerto 9042 en el puerto 9042.
    - Haga clic en **Run**.
2. **Por consola**
    - `docker pull cassandra:latest` para obtener la última imagen de Cassandra.
    - `docker run -p 127.0.0.1:9042:9042 --name cass_cluster cassandra:latest` para instalar un nuevo contenedor de Cassandra en Docker con nombre *cass_cluster*, mapeando el puerto 9042 (derecha) en `127.0.0.1:9042`.

Configurar la aplicación
-------------------------
Modificar **`API/appsettings.json`** según las necesidades:
- ***AppSettings:Cassandra:Username*** es el nombre de usuario con el cual se conecta al contenedor de Cassandra.
- ***AppSettings:Cassandra:Password*** es la contraseña con la cual se conecta al contenedor de Cassandra.
- ***AppSettings:Cassandra:ContactPoint*** es la IP a través de la cual se accede a Cassandra.
- ***AppSettings:Cassandra:Port*** es el puerto en el que se mapeó el puerto 9042 de Cassandra.
- ***AppSettings:Cassandra:Keyspace*** es el nombre del keyspace en el cual guardaremos los datos.

#### IMPORTANTE
Es posible que al intentar conectarse a la IP especificada (sea `127.0.0.1`, `localhost` o cual sea) en el `docker run` no sea suficiente para llegar al contenedor de Cassandra. En ese caso, seguir los siguientes pasos:
1. **Con Docker Desktop**
    - Seleccione el contenedor.
    - Clic en *Exec*.
    - Ejecute `cqlsh`.
2. **Por consola**
    - Ejecute `docker exec -it cass_cluster cqlsh` cambiando *cass_cluster* por el nombre que le puso al contenedor.

Una vez llegados a este punto, independientemente de qué herramienta uso, siga los siguientes pasos:
- Ejecute el siguiente comando: `SELECT listen_address FROM system.local;`
- Use la IP devuelta como *contact point* en `API/appsettings.json`.

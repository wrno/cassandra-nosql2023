# Laboratorio NoSQL: API de domicilios en Cassandra (cassandra-nosql2023)
**Laboratorio 2 de Taller de Bases de Datos NoSQL 2023 utilizando Apache Cassandra.** <br>
El repositorio contiene una solución de .NET cuyo proyecto principal es una API para almacenar en y consultar domicilios desde una base de datos Apache Cassandra.


Grupo
-----
- Acosta, Federico
- Collazo, Bruno
- Grasso, Sebastián


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

Configuración de la aplicación
------------------------------
Modificar **`API/appsettings.json`** según las necesidades:
- ***AppSettings:Cassandra:Username*** es el nombre de usuario con el cual se conecta al contenedor de Cassandra.
- ***AppSettings:Cassandra:Password*** es la contraseña con la cual se conecta al contenedor de Cassandra.
- ***AppSettings:Cassandra:ContactPoint*** es la IP a través de la cual se accede a Cassandra.
- ***AppSettings:Cassandra:Port*** es el puerto en el que se mapeó el puerto 9042 de Cassandra.
- ***AppSettings:Cassandra:Keyspace*** es el nombre del keyspace en el cual guardaremos los datos.

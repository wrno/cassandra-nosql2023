# cassandra-nosql2023
Laboratorio 2 de Taller de Bases de Datos NoSQL 2023 utilizando **Apache Cassandra**.


Grupo
-----
- Acosta, Federico
- Collazo, Bruno
- Grasso, Sebastián


Despliegue de Docker en Windows
-------------------------------
Para poder usar Cassandra, debe asegurarse de tener instalado **Java SE 8 u OpenJDK 8**.

Debe instalar **WSL 2** con **Ubuntu**:
- Ejecute PowerShell como administrador.
- Ejecute el siguiente comando: `wsl --install -d ubuntu`
- Reinicie la computadora y ejecute Ubuntu si no lo hace automáticamente.
- Configure su usuario de Ubuntu.
- Actualice toda aplicación de Ubuntu y repositorios a la última versión usando `sudo apt update` y luego `sudo apt upgrade`.

Ahora puede descargar e instalar **Docker Desktop** desde la [página oficial de Docker](https://www.docker.com/products/docker-desktop/).

Para desplegar Cassandra en Docker, tiene dos opciones:
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
    - Opcionalmente, puede definir nombre y puertos del contenedor.
    - Haga clic en **Run**.
2. **Por consola**
    - `docker pull cassandra:latest` para obtener la última imagen de Cassandra.
    - `docker run --name cass_cluster cassandra:latest` para desplegar un nuevo contenedor en Docker.

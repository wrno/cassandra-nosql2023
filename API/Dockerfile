#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Copia el Secure Connect Bundle al directorio que definamos.
#Modificar el primer parámetro para definir el origen del Secure Connect Bundle en nuestra PC.
#Modificar el segundo parámetro para definir el destino donde se copiará en el contenedor. Debe ser igual al BundlePath de appsettings.json.
COPY ["DAL/Persistence/secure-connect-cass-cluster.zip", "/secure-connect-cass-cluster.zip"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
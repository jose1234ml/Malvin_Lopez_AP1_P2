# Imagen base de ASP.NET 9 para producción
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagen SDK de .NET 9 para compilar y publicar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia el archivo de proyecto y restaura dependencias
COPY ["Malvin_Lopez_AP1_P2/Malvin_Lopez_AP1_P2.csproj", "Malvin_Lopez_AP1_P2/"]
WORKDIR /src/Malvin_Lopez_AP1_P2
RUN dotnet restore "Malvin_Lopez_AP1_P2.csproj"

# Copia el resto de los archivos y publica
COPY Malvin_Lopez_AP1_P2/. .
RUN dotnet publish "Malvin_Lopez_AP1_P2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final para ejecución
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Malvin_Lopez_AP1_P2.dll"]

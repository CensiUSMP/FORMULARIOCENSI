# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el archivo de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código y publicar
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados desde la etapa de construcción
COPY --from=build-env /app/out .

# Definir el nombre del archivo DLL de tu aplicación
ENV APP_NET_CORE=FORMULARIOCENSI.dll

# Comando para ejecutar la aplicación
CMD ["sh", "-c", "ASPNETCORE_URLS=http://*:$PORT dotnet $APP_NET_CORE"]

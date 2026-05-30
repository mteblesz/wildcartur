FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY servartur/servartur.slnx ./
COPY servartur/src/ ./src/
COPY servartur/Directory.*.props ./
COPY servartur/NuGet.config ./

RUN dotnet restore ./servartur.slnx

WORKDIR /src/src/Servartur.Api
RUN dotnet build "Servartur.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish "Servartur.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Servartur.Api.dll"]
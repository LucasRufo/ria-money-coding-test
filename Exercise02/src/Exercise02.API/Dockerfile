FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Exercise02.API/Exercise02.API.csproj", "src/Exercise02.API/"]
COPY ["src/Exercise02.Domain/Exercise02.Domain.csproj", "src/Exercise02.Domain/"]
COPY ["src/Exercise02.Infrastructure/Exercise02.Infrastructure.csproj", "src/Exercise02.Infrastructure/"]
RUN dotnet restore "./src/Exercise02.API/./Exercise02.API.csproj"
COPY . .
WORKDIR "/src/src/Exercise02.API"
RUN dotnet build "./Exercise02.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Exercise02.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exercise02.API.dll"]
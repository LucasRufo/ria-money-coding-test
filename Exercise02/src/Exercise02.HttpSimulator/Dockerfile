FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Exercise02.HttpSimulator/Exercise02.HttpSimulator.csproj", "src/Exercise02.HttpSimulator/"]
COPY ["src/Exercise02.Domain/Exercise02.Domain.csproj", "src/Exercise02.Domain/"]
RUN dotnet restore "./src/Exercise02.HttpSimulator/./Exercise02.HttpSimulator.csproj"
COPY . .
WORKDIR "/src/src/Exercise02.HttpSimulator"
RUN dotnet build "./Exercise02.HttpSimulator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Exercise02.HttpSimulator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exercise02.HttpSimulator.dll"]
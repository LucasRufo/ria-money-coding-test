FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Exercise01.Console/Exercise01.Console.csproj", "src/Exercise01.Console/"]
RUN dotnet restore "./src/Exercise01.Console/./Exercise01.Console.csproj"
COPY . .
WORKDIR "/src/src/Exercise01.Console"
RUN dotnet build "./Exercise01.Console.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Exercise01.Console.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exercise01.Console.dll"]
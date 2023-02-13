#.NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects

COPY PlantHere/PlantHere.Test/*.csproj PlantHere.Test/
COPY PlantHere/PlantHere.Application/*.csproj PlantHere.Application/
COPY PlantHere/PlantHere.Domain/*.csproj PlantHere.Domain/
COPY PlantHere/PlantHere/*.csproj PlantHere/
COPY PlantHere/PlantHere.Infrastructure/*.csproj PlantHere.Infrastructure/
COPY PlantHere/PlantHere.Persistence/*.csproj PlantHere.Persistence/
COPY PlantHere/*.sln .

# .NET Core Restore
RUN dotnet restore

# Copy All Files
COPY . .

# .NET Core Test
RUN dotnet test PlantHere/PlantHere.Test/*.csproj

# .NET Core Build and Publish
RUN dotnet publish ./PlantHere/PlantHere/PlantHere.WebAPI.csproj -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Sets the working directory
WORKDIR /app

# Expose post
EXPOSE 80

# Copy publish
COPY --from=build /publish .

# Run Dll
ENTRYPOINT ["dotnet", "PlantHere.WebAPI.dll"]
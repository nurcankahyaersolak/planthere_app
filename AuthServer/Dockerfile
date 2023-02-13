#.NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects

COPY AuthServer/AuthServer.Application/*.csproj AuthServer.Application/
COPY AuthServer/AuthServer.Domain/*.csproj AuthServer.Domain/
COPY AuthServer/AuthServer.API/*.csproj AuthServer.API/
COPY AuthServer/AuthServer.Infrastructure/*.csproj AuthServer.Infrastructure/
COPY AuthServer/AuthServer.Persistence/*.csproj AuthServer.Persistence/
COPY AuthServer/*.sln .

# .NET Core Restore
RUN dotnet restore

# Copy All Files
COPY . .

# .NET Core Build and Publish
RUN dotnet publish ./AuthServer/AuthServer.API/AuthServer.API.csproj -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base 

# Sets the working directory
WORKDIR /app

# Expose post
EXPOSE 80

# Copy publish
COPY --from=build /publish .

# Run Dll
ENTRYPOINT ["dotnet", "AuthServer.API.dll"]
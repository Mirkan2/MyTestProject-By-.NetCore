# Base image for the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image for the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyTestProject.csproj", "."]
RUN dotnet restore "./MyTestProject.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MyTestProject.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "MyTestProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTestProject.dll"]

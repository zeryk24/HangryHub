#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Host/HangryHub.RestaurantService.Host.csproj", "Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Host/"]
COPY ["Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Application/HangryHub.RestaurantService.Application.csproj", "Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Application/"]
COPY ["Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Domain/HangryHub.RestaurantService.Domain.csproj", "Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Domain/"]
COPY ["Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Infrastructure/HangryHub.RestaurantService.Infrastructure.csproj", "Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Infrastructure/"]
COPY ["Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Presentation/HangryHub.RestaurantService.Presentation.csproj", "Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Presentation/"]
COPY ["Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Contracts/HangryHub.RestaurantService.Contracts.csproj", "Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Contracts/"]
RUN dotnet restore "./Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Host/./HangryHub.RestaurantService.Host.csproj"
COPY . .
WORKDIR "/src/Backend/HangryHub.RestaurantService/HangryHub.RestaurantService.Host"
RUN dotnet build "./HangryHub.RestaurantService.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HangryHub.RestaurantService.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HangryHub.RestaurantService.Host.dll"]
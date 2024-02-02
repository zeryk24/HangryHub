#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/HangryHub.OrderService/HangryHub.OrderService.API/HangryHub.OrderService.API.csproj", "Backend/HangryHub.OrderService/HangryHub.OrderService.API/"]
COPY ["Backend/HangryHub.OrderService/HangryHub.OderService.UseCases/HangryHub.OderService.UseCases.csproj", "Backend/HangryHub.OrderService/HangryHub.OderService.UseCases/"]
COPY ["Backend/HangryHub.OrderService/HangryHub.OrderService.Core/HangryHub.OrderService.Core.csproj", "Backend/HangryHub.OrderService/HangryHub.OrderService.Core/"]
COPY ["Backend/HangryHub.OrderService/HangryHub.OrderService.Infrastructure/HangryHub.OrderService.Infrastructure.csproj", "Backend/HangryHub.OrderService/HangryHub.OrderService.Infrastructure/"]
RUN dotnet restore "./Backend/HangryHub.OrderService/HangryHub.OrderService.API/./HangryHub.OrderService.API.csproj"
COPY . .
WORKDIR "/src/Backend/HangryHub.OrderService/HangryHub.OrderService.API"
RUN dotnet build "./HangryHub.OrderService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HangryHub.OrderService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir sqlitedb
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HangryHub.OrderService.API.dll"]
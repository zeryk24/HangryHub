#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Backend/HangryHub.DeliveryService/HangryHub.DeliveryService.API/HangryHub.DeliveryService.API.csproj", "Backend/HangryHub.DeliveryService/HangryHub.DeliveryService.API/"]
RUN dotnet restore "Backend/HangryHub.DeliveryService/HangryHub.DeliveryService.API/HangryHub.DeliveryService.API.csproj"
COPY . .
WORKDIR "/src/Backend/HangryHub.DeliveryService/HangryHub.DeliveryService.API"
RUN dotnet build "HangryHub.DeliveryService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HangryHub.DeliveryService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN mkdir sqlitedb
ENTRYPOINT ["dotnet", "HangryHub.DeliveryService.API.dll"]
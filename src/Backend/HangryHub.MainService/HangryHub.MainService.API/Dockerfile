FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/HangryHub.MainService/HangryHub.MainService.API/HangryHub.MainService.API.csproj", "Backend/HangryHub.MainService/HangryHub.MainService.API/"]
COPY ["Backend/HangryHub.MainService/HangryHub.MainService.Application/HangryHub.MainService.Application.csproj", "Backend/HangryHub.MainService/HangryHub.MainService.Application/"]
COPY ["Backend/HangryHub.MainService/HangryHub.MainService.Domain/HangryHub.MainService.Domain.csproj", "Backend/HangryHub.MainService/HangryHub.MainService.Domain/"]
COPY ["Backend/HangryHub.MainService/HangryHub.MainService.Infrastructure/HangryHub.MainService.Infrastructure.csproj", "Backend/HangryHub.MainService/HangryHub.MainService.Infrastructure/"]
COPY ["Backend/HangryHub.MainService/HangryHub.MainService.Contracts/HangryHub.MainService.Contracts.csproj", "Backend/HangryHub.MainService/HangryHub.MainService.Contracts/"]
RUN dotnet restore "./Backend/HangryHub.MainService/HangryHub.MainService.API/./HangryHub.MainService.API.csproj"
COPY . .
WORKDIR "/src/Backend/HangryHub.MainService/HangryHub.MainService.API"
RUN dotnet build "./HangryHub.MainService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HangryHub.MainService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HangryHub.MainService.API.dll"]
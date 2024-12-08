FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Adapters/Driver/API/FoodOrder.API.csproj", "src/Adapters/Driver/API/"] 
COPY ["src/Core/Application/FoodOrder.Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/FoodOrder.Domain.csproj", "src/Core/Domain/"]
COPY ["src/Adapters/Driven/Infra.Data/FoodOrder.Data.csproj", "src/Adapters/Driven/Infra.Data/"]
RUN dotnet restore "./src/Adapters/Driver/API/FoodOrder.API.csproj"

COPY . .
WORKDIR "/src/src/Adapters/Driver/API"
RUN dotnet build "./FoodOrder.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FoodOrder.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

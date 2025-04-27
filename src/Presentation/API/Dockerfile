FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/API/FoodOrder.Api.csproj", "src/Presentation/API/"] 
RUN ls -la ./src/Presentation/API
COPY ["src/Core/Application/FoodOrder.Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/FoodOrder.Domain.csproj", "src/Core/Domain/"]
COPY ["src/Infrastructure/Infra.Data/FoodOrder.Data.csproj", "src/Infrastructure/Infra.Data/"]
RUN dotnet restore "./src/Presentation/API/FoodOrder.Api.csproj"

COPY . .
WORKDIR "/src/src/Presentation/API"
RUN dotnet build "./FoodOrder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FoodOrder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ls -la
ENTRYPOINT ["dotnet", "FoodOrder.API.dll"]

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Identity/GShop.Identity/GShop.Identity.csproj", "Systems/Identity/GShop.Identity/"]
COPY ["Data/GShop.Context/GShop.Context.csproj", "Data/GShop.Context/"]
COPY ["Services/GShop.Services.Settings/GShop.Services.Settings.csproj", "Services/GShop.Services.Settings/"]
COPY ["Shared/GShop.Common/GShop.Common.csproj", "Shared/GShop.Common/"]
COPY ["Data/GShop.Context.Entities/GShop.Context.Entities.csproj", "Data/GShop.Context.Entities/"]
RUN dotnet restore "./Systems/Identity/GShop.Identity/./GShop.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/GShop.Identity"
RUN dotnet build "./GShop.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GShop.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GShop.Identity.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Api/GShop.api/GShop.api.csproj", "Systems/Api/GShop.api/"]
COPY ["Data/GShop.Context.Migrations/GShop.Context.Migrations.MSSQL/GShop.Context.Migrations.MSSQL.csproj", "Data/GShop.Context.Migrations/GShop.Context.Migrations.MSSQL/"]
COPY ["Data/GShop.Context/GShop.Context.csproj", "Data/GShop.Context/"]
COPY ["Services/GShop.Services.Settings/GShop.Services.Settings.csproj", "Services/GShop.Services.Settings/"]
COPY ["Shared/GShop.Common/GShop.Common.csproj", "Shared/GShop.Common/"]
COPY ["Data/GShop.Context.Entities/GShop.Context.Entities.csproj", "Data/GShop.Context.Entities/"]
COPY ["Data/GShop.Context.Migrations/GShop.Context.Migrations.MySql/GShop.Context.Migrations.MySql.csproj", "Data/GShop.Context.Migrations/GShop.Context.Migrations.MySql/"]
COPY ["Data/GShop.Context.Migrations/GShop.Context.Migrations.PgSql/GShop.Context.Migrations.PgSql.csproj", "Data/GShop.Context.Migrations/GShop.Context.Migrations.PgSql/"]
COPY ["Data/GShop.Context.Seeder/GShop.Context.Seeder.csproj", "Data/GShop.Context.Seeder/"]
COPY ["Services/GShop.Services.Actions/GShop.Services.Actions.csproj", "Services/GShop.Services.Actions/"]
COPY ["Services/GShop.Services.RabbitMq/GShop.Services.RabbitMq.csproj", "Services/GShop.Services.RabbitMq/"]
COPY ["Services/GShop.Services.Gadgets/GShop.Services.Gadgets.csproj", "Services/GShop.Services.Gadgets/"]
COPY ["Services/GShop.Services.Logger/GShop.Services.Logger.csproj", "Services/GShop.Services.Logger/"]
COPY ["Systems/Api/Gshop.Api.Settings/Gshop.Api.Settings.csproj", "Systems/Api/Gshop.Api.Settings/"]
RUN dotnet restore "./Systems/Api/GShop.api/./GShop.api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/GShop.api"
RUN dotnet build "./GShop.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GShop.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GShop.api.dll"]
# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
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
COPY ["Services/GShop.Services.UserAccount/GShop.Services.UserAccount.csproj", "Services/GShop.Services.UserAccount/"]
COPY ["Services/GShop.Services.Actions/GShop.Services.Actions.csproj", "Services/GShop.Services.Actions/"]
COPY ["Services/GShop.Services.RabbitMq/GShop.Services.RabbitMq.csproj", "Services/GShop.Services.RabbitMq/"]
COPY ["Services/GShop.Services.ContextAccess/GShop.Services.ContextAccess.csproj", "Services/GShop.Services.ContextAccess/"]
COPY ["Services/GShop.Services.Gadgets/GShop.Services.Gadgets.csproj", "Services/GShop.Services.Gadgets/"]
COPY ["Services/GShop.Services.Images/GShop.Services.Images.csproj", "Services/GShop.Services.Images/"]
COPY ["Services/GShop.Services.Likes/GShop.Services.Likes.csproj", "Services/GShop.Services.Likes/"]
COPY ["Services/GShop.Services.Logger/GShop.Services.Logger.csproj", "Services/GShop.Services.Logger/"]
COPY ["Services/GShop.Services.Orders/GShop.Services.Orders.csproj", "Services/GShop.Services.Orders/"]
COPY ["Systems/Api/Gshop.Api.Settings/Gshop.Api.Settings.csproj", "Systems/Api/Gshop.Api.Settings/"]
RUN dotnet restore "./Systems/Api/GShop.api/GShop.api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/GShop.api"
RUN dotnet build "./GShop.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GShop.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GShop.api.dll"]
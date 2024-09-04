#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Workers/GShop.EmailSender/GShop.EmailSender.csproj", "Systems/Workers/GShop.EmailSender/"]
COPY ["Services/GShop.Services.Actions/GShop.Services.Actions.csproj", "Services/GShop.Services.Actions/"]
COPY ["Services/GShop.Services.RabbitMq/GShop.Services.RabbitMq.csproj", "Services/GShop.Services.RabbitMq/"]
COPY ["Shared/GShop.Common/GShop.Common.csproj", "Shared/GShop.Common/"]
COPY ["Services/GShop.Services.Logger/GShop.Services.Logger.csproj", "Services/GShop.Services.Logger/"]
COPY ["Services/GShop.Services.Settings/GShop.Services.Settings.csproj", "Services/GShop.Services.Settings/"]
RUN dotnet restore "./Systems/Workers/GShop.EmailSender/./GShop.EmailSender.csproj"
COPY . .
WORKDIR "/src/Systems/Workers/GShop.EmailSender"
RUN dotnet build "./GShop.EmailSender.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GShop.EmailSender.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GShop.EmailSender.dll"]
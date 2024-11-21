# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/LotDesignerMicroservice.Presentation.WebApi/LotDesignerMicroservice.Presentation.WebApi.csproj", "Presentation/LotDesignerMicroservice.Presentation.WebApi/"]
COPY ["Application/LotDesignerMicroservice.Application.Models/LotDesignerMicroservice.Application.Models.csproj", "Application/LotDesignerMicroservice.Application.Models/"]
COPY ["Domain/Entities/LotDesignerMicroservice.Domain.Entities.csproj", "Domain/Entities/"]
COPY ["Domain/ValueObjects/LotDesignerMicroservice.Domain.ValueObjects.csproj", "Domain/ValueObjects/"]
COPY ["Application/LotDesignerMicroservice.Application.Services/LotDesignerMicroservice.Application.Services.csproj", "Application/LotDesignerMicroservice.Application.Services/"]
COPY ["Domain/RepositoriesAbstractions/LotDesignerMicroservice.Domain.RepositoriesAbstractions.csproj", "Domain/RepositoriesAbstractions/"]
COPY ["Infrastructure/EfRepository/LotDesignerMicroservice.Infrastructure.EfRepository.csproj", "Infrastructure/EfRepository/"]
RUN dotnet restore "./Presentation/LotDesignerMicroservice.Presentation.WebApi/LotDesignerMicroservice.Presentation.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/LotDesignerMicroservice.Presentation.WebApi"
RUN dotnet build "./LotDesignerMicroservice.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LotDesignerMicroservice.Presentation.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LotDesignerMicroservice.Presentation.WebApi.dll"]
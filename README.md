# OrganizedScannAPI — Clean Code, DDD e Clean Architecture (nomes originais)

Estruturado em **camadas** mantendo o nome base do projeto.

## Estrutura
```
src
 ┣ OrganizedScannAPI.Api           -> Controllers, Middlewares, Swagger
 ┣ OrganizedScannAPI.Application           -> UseCases, DTOs
 ┣ OrganizedScannAPI.Domain           -> Entidades, Enums, Value Objects, Interfaces de Repositório
 ┗ OrganizedScannAPI.Infrastructure           -> EF Core (Oracle), DbContext, Repositórios (implementações), DI
```

## Como executar
```bash
cd src
dotnet new sln -n OrganizedScannAPI
dotnet sln add OrganizedScannAPI.Domain/OrganizedScannAPI.Domain.csproj
dotnet sln add OrganizedScannAPI.Application/OrganizedScannAPI.Application.csproj
dotnet sln add OrganizedScannAPI.Infrastructure/OrganizedScannAPI.Infrastructure.csproj
dotnet sln add OrganizedScannAPI.Api/OrganizedScannAPI.Api.csproj

# Ajuste a connection string em OrganizedScannAPI.Api/appsettings.json

# Migrations (opcional)
dotnet ef migrations add Initial --project OrganizedScannAPI.Infrastructure --startup-project OrganizedScannAPI.Api
dotnet ef database update --project OrganizedScannAPI.Infrastructure --startup-project OrganizedScannAPI.Api

# Rodar API
dotnet run --project OrganizedScannAPI.Api/OrganizedScannAPI.Api.csproj
```

## Swagger
Disponível em `/swagger`.

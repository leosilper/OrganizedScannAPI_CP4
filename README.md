# OrganizedScannAPI 🚀

API REST desenvolvida em **.NET 8** seguindo princípios de **Clean Architecture** e **DDD (Domain-Driven Design)**.  
O objetivo é fornecer uma estrutura organizada para o gerenciamento de **motocicletas, portais e usuários**, com **persistência em MongoDB**, **Health Check**, **Versionamento de API** e boas práticas de desenvolvimento.

---

## ✅ Checkpoint 5 - Requisitos Implementados

### 1. Clean Architecture (1.0 ponto) ✅
- ✅ Separação clara em 4 camadas (Api, Application, Domain, Infrastructure)
- ✅ Baixo acoplamento e alta coesão
- ✅ Lógica de negócio centralizada no domínio
- ✅ Interface de repositório definida dentro do domínio

### 2. Domain-Driven Design (1.0 ponto) ✅
- ✅ Entidades ricas: `Motorcycle`, `Portal`, `User`
- ✅ Agregado raiz: Motorcycle com relacionamento a Portal
- ✅ Value Objects: `Email`, `LicensePlate`
- ✅ Interfaces de repositório no domínio

### 3. Clean Code (1.0 ponto) ✅
- ✅ **SRP**: Cada classe tem uma única responsabilidade
- ✅ **DRY**: Sem duplicação de código
- ✅ **KISS**: Soluções simples e objetivas
- ✅ **YAGNI**: Implementado apenas o necessário
- ✅ Nomeação clara e código legível

### 4. MongoDB - CRUD Completo (3.0 pontos) ✅
- ✅ Conexão com MongoDB implementada
- ✅ Repositórios MongoDB para todas as entidades
- ✅ CRUD completo para Motorcycles, Portals e Users
- ✅ DTOs e validações nas requisições
- ✅ Instruções de configuração no README

### 5. Health Check (2.0 pontos) ✅
- ✅ Endpoint `/health` configurado
- ✅ Verificação da conectividade com MongoDB
- ✅ Verificação de auto-saúde da aplicação

### 6. Swagger + Versionamento (1.0 ponto) ✅
- ✅ Swagger configurado com versionamento (v1, v2)
- ✅ Endpoints documentados com exemplos e responses
- ✅ Cabeçalho com nome, descrição e versão da API
- ✅ Endpoints disponíveis em:
  - `GET /api/v1/motorcycle`
  - `GET /api/v2/motorcycles`

### 7. Organização GitHub + Commits (1.0 ponto) ✅
- ✅ Estrutura de pastas coerente (Clean Architecture)
- ✅ Commits semânticos implementados
- ✅ README completo e atualizado
- ✅ Código organizado e limpo

**Total: 10.0 pontos**

---

## 📂 Estrutura do Projeto

```
src/
 ┣ 📂 Api             → Controllers, Middlewares, Swagger, Program.cs
 ┣ 📂 Application     → Casos de uso, DTOs, MotorcycleService
 ┣ 📂 Domain          → Entidades, Value Objects, Interfaces de repositório
 ┗ 📂 Infrastructure  → MongoDB, Repositórios, DependencyInjection
```

---

## ⚙️ Tecnologias Utilizadas

- **.NET 8** (ASP.NET Core Web API)
- **MongoDB** com MongoDB.Driver
- **MongoDB Health Checks** (AspNetCore.HealthChecks.MongoDb)
- **Swagger / Swashbuckle** (documentação com versionamento)
- **API Versioning** (Microsoft.AspNetCore.Mvc.Versioning)
- **Clean Architecture + DDD**
- **Middleware de tratamento de erros**
- **CORS configurado**

---

## 🚀 Como Executar o Projeto

### 1️⃣ Pré-requisitos

- .NET 8 SDK instalado
- MongoDB instalado localmente ou MongoDB Atlas (cloud)
- Visual Studio 2022 ou VS Code

### 2️⃣ Clonar o repositório

```bash
git clone https://github.com/seu-usuario/OrganizedScannAPI.git
cd OrganizedScannAPI
```

### 3️⃣ Configurar MongoDB

#### Opção A: MongoDB Local

1. Instale o MongoDB localmente: https://www.mongodb.com/try/download/community
2. Configure a connection string em `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "MongoDB": "mongodb://localhost:27017"
     },
     "MongoDB": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "OrganizedScannDB"
     }
   }
   ```

#### Opção B: MongoDB Atlas (Cloud)

1. Crie uma conta em https://www.mongodb.com/atlas
2. Crie um cluster gratuito
3. Obtenha a connection string
4. Configure em `appsettings.json`:
   ```json
   {
     "MongoDB": {
       "ConnectionString": "mongodb+srv://usuario:senha@cluster.mongodb.net/OrganizedScannDB",
       "DatabaseName": "OrganizedScannDB"
     }
   }
   ```

### 4️⃣ Restaurar pacotes NuGet

```bash
dotnet restore
```

### 5️⃣ Executar a aplicação

```bash
cd src/OrganizedScannAPI.Api
dotnet run
```

A API estará disponível em:  
👉 `https://localhost:5001/swagger` (com Swagger UI habilitado)

---

## 📌 Endpoints da API

### Motorcycles (Versão 1)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/v1/motorcycle` | Lista todas as motos |
| GET | `/api/v1/motorcycle/{id}` | Detalhes de uma moto |
| POST | `/api/v1/motorcycle` | Cria nova moto |
| PUT | `/api/v1/motorcycle/{id}` | Atualiza moto |
| DELETE | `/api/v1/motorcycle/{id}` | Remove moto |

### Motorcycles (Versão 2)

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/v2/motorcycles` | Lista todas as motos (V2) |
| GET | `/api/v2/motorcycles/{id}` | Detalhes de uma moto (V2) |
| POST | `/api/v2/motorcycles` | Cria nova moto (V2) |

### Portals

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/v1/portal` | Lista todos os portais |
| GET | `/api/v1/portal/{id}` | Detalhes de um portal |
| POST | `/api/v1/portal` | Cria novo portal |

### Users

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/v1/user` | Lista todos os usuários |
| GET | `/api/v1/user/{id}` | Detalhes de um usuário |
| POST | `/api/v1/user` | Cria novo usuário |
| DELETE | `/api/v1/user/{id}` | Remove usuário |

### Health Check

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/health` | Status da aplicação e MongoDB |

---

## 🗄️ Estrutura de Dados (MongoDB)

### Motorcycle
```json
{
  "id": 1,
  "licensePlate": "ABC-1234",
  "rfid": "RFID123456",
  "problemDescription": "Problema no motor",
  "portalId": 1,
  "entryDate": "2024-01-15T10:00:00Z",
  "availabilityForecast": "2024-01-20T18:00:00Z",
  "brand": "Honda",
  "year": 2022
}
```

### Portal
```json
{
  "id": 1,
  "type": "Entrada",
  "name": "Portal Norte"
}
```

### User
```json
{
  "id": 1,
  "email": "user@example.com",
  "password": "hashedPassword",
  "role": "Admin"
}
```

---

## 🏗️ Arquitetura

### Camada Api
- `Controllers`: Endpoints versionados (v1, v2)
- `Middlewares`: Tratamento de erros
- `Program.cs`: Configuração da aplicação

### Camada Application
- `MotorcycleService`: Lógica de negócio para motocicletas
- `DTOs`: Data Transfer Objects

### Camada Domain
- `Entities`: Motorcycle, Portal, User
- `ValueObjects`: Email, LicensePlate
- `Repositories`: Interfaces IMotorcycleRepository, IPortalRepository, IUserRepository

### Camada Infrastructure
- `MongoDbContext`: Conexão com MongoDB
- `Repositories`: Implementações MongoDB
- `DependencyInjection`: Configuração de serviços

---

## 🛠️ Middleware de Erros

Todas as exceções são tratadas de forma centralizada pelo middleware:

```csharp
app.UseMiddleware<ErrorHandlingMiddleware>();
```

Isso garante respostas consistentes e legíveis para o cliente.

---

## 🔍 Health Check

A aplicação possui um endpoint de health check que monitora:
- Status da própria aplicação
- Conectividade com MongoDB

Acesse: `GET /health`

Resposta exemplo:
```json
{
  "status": "Healthy",
  "checks": {
    "self": "Healthy",
    "mongodb": "Healthy"
  }
}
```

---

## 📊 Swagger / Documentação

A documentação interativa está disponível em:
- `https://localhost:5001/swagger`

### Versionamento
- **v1**: API estável atual
- **v2**: API com novas funcionalidades (em desenvolvimento)

### Documentação
- Todos os endpoints estão documentados
- Exemplos de request/response disponíveis
- Schemas de validação incluídos

---

## 🧪 Testando a API

### Postman / Insomnia

Importe a collection disponível em `/docs/api-collection.json`

### cURL

```bash
# Health Check
curl https://localhost:5001/health

# Listar todas as motos
curl https://localhost:5001/api/v1/motorcycle

# Criar uma moto
curl -X POST https://localhost:5001/api/v1/motorcycle \
  -H "Content-Type: application/json" \
  -d '{
    "licensePlate": "ABC-1234",
    "rfid": "RFID123",
    "problemDescription": "Problema no motor",
    "portalId": 1,
    "entryDate": "2024-01-15T10:00:00Z",
    "availabilityForecast": "2024-01-20T18:00:00Z",
    "brand": "Honda",
    "year": 2022
  }'
```

---

## 📝 Princípios Aplicados

### Clean Code
- **SRP** (Single Responsibility Principle): Cada classe tem uma única responsabilidade
- **DRY** (Don't Repeat Yourself): Código reutilizável, sem duplicação
- **KISS** (Keep It Simple, Stupid): Soluções simples e diretas
- **YAGNI** (You Aren't Gonna Need It): Implementado apenas o necessário

### SOLID
- **S**ingle Responsibility: Cada repositório, serviço e controller tem uma responsabilidade única
- **O**pen/Closed: Extensível através de interfaces
- **L**iskov Substitution: Implementações respeitam contratos de interfaces
- **I**nterface Segregation: Interfaces específicas e focadas
- **D**ependency Inversion: Dependências via interfaces

---

## 🚀 Deploy

### Docker (Opcional)

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["OrganizedScannAPI.Api/OrganizedScannAPI.Api.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "OrganizedScannAPI.Api.dll"]
```

---

## 👥 Integrantes do Grupo

| Nome | RM |
|------|-----|
| Leonardo da Silva Pereira | 557598 |
| Bruno da Silva Souza | 94346 |
| Julio Samuel de Oliveira | 557453 |

---

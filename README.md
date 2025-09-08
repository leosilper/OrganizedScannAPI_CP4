# OrganizedScannAPI 🚀

API REST desenvolvida em **.NET 8** seguindo princípios de **Clean Architecture** e **DDD (Domain-Driven Design)**.  
O objetivo é fornecer uma estrutura organizada para o gerenciamento de **motocicletas, portais e usuários**, com **persistência em banco de dados Oracle**, documentação via **Swagger** e boas práticas de desenvolvimento.

---

## 📂 Estrutura do Projeto

```
src/
 ┣ OrganizedScannAPI.Api/           → Camada de apresentação (Controllers, Middlewares, Configurações)
 ┣ OrganizedScannAPI.Application/   → Camada de aplicação (Serviços, DTOs, Validações)
 ┣ OrganizedScannAPI.Domain/        → Entidades de domínio (Motorcycle, Portal, User)
 ┣ OrganizedScannAPI.Infrastructure/→ Persistência (DbContext, Repositórios, Oracle/EF Core)
```

---

## ⚙️ Tecnologias Utilizadas

- **.NET 8 (ASP.NET Core Web API)**
- **Entity Framework Core** (com suporte a Oracle e H2)
- **Swagger / Swashbuckle** (documentação)
- **FluentValidation** (validações)
- **Mapster** (mapeamento de objetos DTO ↔ Entidades)
- **Clean Architecture + DDD**
- **Middleware de tratamento de erros**

---

## 🚀 Como Executar o Projeto

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/seu-usuario/OrganizedScannAPI.git
cd OrganizedScannAPI/src/OrganizedScannAPI.Api
```

### 2️⃣ Restaurar pacotes
```bash
dotnet restore
```

### 3️⃣ Rodar a aplicação
```bash
dotnet run
```

A API estará disponível em:  
👉 `https://localhost:5001/swagger` (com Swagger UI habilitado)

---

## 🗄️ Banco de Dados

O projeto suporta **Oracle Database** via `Oracle.EntityFrameworkCore`.  
As configurações estão em `appsettings.json`.

Exemplo:
```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=usuario;Password=senha;Data Source=localhost:1521/xe"
}
```

Rodar migrations:
```bash
dotnet ef database update
```

---

## 📌 Endpoints Principais

### 🔹 Motorcycles
- `GET /api/motorcycles` → Lista todas as motos  
- `GET /api/motorcycles/{id}` → Detalhes de uma moto  
- `POST /api/motorcycles` → Cria nova moto  
- `PUT /api/motorcycles/{id}` → Atualiza moto  
- `DELETE /api/motorcycles/{id}` → Remove moto  

### 🔹 Portals
- `GET /api/portals` → Lista todos os portais  
- `POST /api/portals` → Cria novo portal  

### 🔹 Users
- `GET /api/users` → Lista todos os usuários  
- `POST /api/users` → Cria novo usuário (com senha criptografada)

---

## 🛠️ Middleware de Erros

Todas as exceções são tratadas de forma centralizada pelo middleware:
```csharp
app.UseMiddleware<ErrorHandlingMiddleware>();
```
Isso garante respostas consistentes e legíveis para o cliente.

---

# 👥 Intregantes do Grupo

| Nome | RM |
|-------|----|
| Leonardo da Silva Pereira | 557598 |
| Bruno da Silva Souza | 94346 |
| Julio Samuel de Oliveira | 557453 |

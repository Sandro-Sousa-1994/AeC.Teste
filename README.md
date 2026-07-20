# AeC.Teste

Projeto desenvolvido como teste técnico utilizando ASP.NET Core MVC (.NET 10).

## Objetivo

Desenvolver uma aplicação ASP.NET Core MVC para gerenciamento de usuários e endereços, contemplando autenticação, integração com ViaCEP e exportação de dados em CSV.

---

## Tecnologias utilizadas

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Cookie Authentication
- ViaCEP API

---

## Arquitetura

O projeto foi organizado utilizando uma arquitetura em camadas:

```
Controllers
    ↓
Services
    ↓
Entity Framework Core
    ↓
SQL Server
```

Principais diretórios:

```
AeC.Teste.Web
│
├── Controllers
├── Data
├── Models
├── Services
│   ├── Interfaces
│   └── Dtos
├── ViewModels
├── Views
└── wwwroot
```

---

## Funcionalidades

### Autenticação

- Login utilizando Cookie Authentication
- Logout
- Senhas armazenadas com PasswordHasher
- Usuário administrador criado automaticamente via Seed

### Usuários

- Listagem
- Cadastro
- Edição
- Exclusão
- Validação de usuário duplicado
- Exportação para CSV

### Endereços

- Listagem
- Cadastro
- Edição
- Exclusão
- Relacionamento com Usuários

### ViaCEP

- Consulta automática por CEP
- Preenchimento automático de:
  - Rua
  - Bairro
  - Cidade
  - Estado

---

## Como executar

### 1. Configurar a Connection String

Edite o arquivo:

```
appsettings.json
```

e configure a conexão com o SQL Server.

## Banco de Dados

O projeto utiliza SQL Server.

Foi disponibilizado o script de criação da estrutura das tabelas em:

```
database/001_CreateTables.sql
```

Também é possível criar o banco utilizando as migrations do Entity Framework Core:

```bash
dotnet ef database update
```

---

### 2. Executar as migrations

```bash
dotnet ef database update
```

---

### 3. Executar a aplicação

Pelo Visual Studio:

- Defina **AeC.Teste.Web** como Startup Project.
- Pressione **F5**.

Ou pelo terminal:

```bash
dotnet run
```

---

## Usuário padrão

Após executar a aplicação será criado automaticamente:

| Usuário | Senha |
|----------|--------|
| admin | 123456 |

---

## Funcionalidades implementadas

- ✅ Autenticação
- ✅ CRUD de Usuários
- ✅ CRUD de Endereços
- ✅ Integração ViaCEP
- ✅ Exportação CSV
- ✅ Entity Framework Core
- ✅ Fluent API
- ✅ ViewModels
- ✅ Services
- ✅ Dependency Injection
- ✅ Async/Await

---

## Estrutura do projeto

```
AeC.Teste
│
├── database
├── AeC.Teste.Web
│   ├── Controllers
│   ├── Data
│   ├── Extensions
│   ├── Models
│   ├── Services
│   ├── ViewModels
│   ├── Views
│   └── wwwroot
│
└── README.md
```

---

## Observações

O projeto foi desenvolvido priorizando:

- Organização do código
- Separação de responsabilidades
- Simplicidade
- Boas práticas do ASP.NET Core MVC
- Utilização de Services para concentrar a lógica de negócio
- Controllers responsáveis apenas pelo fluxo da aplicação

## Requisitos

- .NET 10 SDK
- SQL Server
- Visual Studio 2022 ou superior
# FundooApp — User Module (Day-wise Task)

A layered ASP.NET Core Web API implementing user **registration** and **login** with JWT authentication, following clean N-layer architecture. This is a scoped-down version containing only the User module (Notes functionality is tracked as a separate day's task).

## Project Structure

```
FundooApp/
├── FundooApp.sln
├── FundooApp.API/                 # Presentation layer - Controllers, Program.cs, appsettings
│   └── Controllers/
│       └── UserController.cs
├── FundooApp.BusinessLayer/       # Business logic layer
│   ├── Interfaces/
│   │   └── IUserBusiness.cs
│   └── Services/
│       └── UserBusiness.cs
├── FundooApp.ModelLayer/          # Entities, DTOs, custom exceptions
│   ├── DTOs/
│   │   ├── LoginDTO.cs
│   │   ├── RegistrationDTO.cs
│   │   └── ResponseDTO.cs
│   ├── Entities/
│   │   └── User.cs
│   └── Exceptions/
│       ├── InvalidCredentialsException.cs
│       └── UserNotFoundException.cs
└── FundooApp.RepositoryLayer/     # Data access layer (EF Core)
    ├── Context/
    │   └── FundooDbContext.cs
    ├── Interfaces/
    │   └── IUserRepository.cs
    └── Repositories/
        └── UserRepository.cs
```

## Layers

- **ModelLayer** — POCOs (`Entities`), request/response contracts (`DTOs`), and custom exceptions (`Exceptions`). No dependencies on other layers.
- **RepositoryLayer** — EF Core `DbContext` and repository classes that talk to the database. Depends on `ModelLayer`.
- **BusinessLayer** — Business rules, password hashing (BCrypt), JWT generation. Depends on `ModelLayer` + `RepositoryLayer`.
- **API** — ASP.NET Core Web API controllers, DI wiring, Swagger, JWT auth. Depends on all three.

## Getting Started

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download).
2. Update the connection string in `FundooApp.API/appsettings.json` to match your SQL Server instance.
3. From the solution root:

```bash
dotnet restore
cd FundooApp.API
dotnet ef migrations add InitialCreate --project ../FundooApp.RepositoryLayer --startup-project .
dotnet ef database update --project ../FundooApp.RepositoryLayer --startup-project .
cd ..
dotnet run --project FundooApp.API
```

4. Browse to `https://localhost:<port>/swagger` to test the endpoints.

> **Note:** the `Migrations` folder is intentionally not committed — each environment generates its own on first run via `dotnet ef migrations add`.

## Endpoints

| Method | Route               | Description          | Auth |
|--------|---------------------|-----------------------|------|
| POST   | /api/User/register  | Register a new user   | No   |
| POST   | /api/User/login     | Login, returns JWT    | No   |

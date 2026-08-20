# FundooApp — Day 14: Complete Auth Module + Notes Create/Delete

BridgeLabz Backend Refresher — .NET 20-Day Plan, **Day 14**: JWT, AuthN vs AuthZ, OAuth & SSO.

Scope for this day (per training roadmap):
- Complete the Authentication & Authorization module
- Begin the Notes Management module: **create** and **delete** notes only (list/search and pin/archive/trash edits are Day 15–16 work)

## Project Structure

```
FundooApp/
├── FundooApp.sln
├── FundooApp.API/
│   └── Controllers/
│       ├── UserController.cs      # register, login, [Authorize] profile
│       └── NoteController.cs      # [Authorize] create + delete only (Day 14 scope)
├── FundooApp.BusinessLayer/
│   ├── Interfaces/
│   │   ├── IUserBusiness.cs
│   │   └── INoteBusiness.cs
│   └── Services/
│       ├── UserBusiness.cs
│       └── NoteBusiness.cs
├── FundooApp.ModelLayer/
│   ├── DTOs/
│   ├── Entities/
│   │   ├── User.cs
│   │   └── Note.cs
│   └── Exceptions/
└── FundooApp.RepositoryLayer/
    ├── Context/
    │   └── FundooDbContext.cs
    ├── Interfaces/
    │   ├── IUserRepository.cs
    │   └── INoteRepository.cs
    └── Repositories/
        ├── UserRepository.cs      # builds User entity, hashes password
        └── NoteRepository.cs
```

## Layers

- **ModelLayer** — Entities, DTOs, custom exceptions. No dependencies on other layers.
- **RepositoryLayer** — EF Core `DbContext` and repositories. `UserRepository` builds the `User` entity and hashes the password with BCrypt before saving. Depends on `ModelLayer`.
- **BusinessLayer** — Orchestration and rules (duplicate-email check, JWT generation, note ownership checks). Depends on `ModelLayer` + `RepositoryLayer`.
- **API** — Controllers, DI wiring, Swagger, JWT auth middleware. Depends on all three.

## Auth Module (complete)

- `POST /api/User/register` — creates a user, password hashed + salted via BCrypt (in `UserRepository`)
- `POST /api/User/login` — verifies credentials, issues a signed JWT (24h expiry)
- `GET /api/User/profile` — `[Authorize]`-protected, returns the caller's own profile from JWT claims

## Notes Module (Day 14 scope: create + delete)

- `POST /api/Note` — `[Authorize]`-protected, creates a note owned by the logged-in user
- `DELETE /api/Note/{noteId}` — `[Authorize]`-protected, deletes a note only if it belongs to the logged-in user

> `GetAllNotes` and `UpdateNote` already exist in `INoteBusiness`/`NoteBusiness` but are intentionally not exposed on the controller yet — they're reserved for Day 15–16 (EF/CQRS deep-dive, Pin/Archive/Trash, Search & Filter) per the roadmap.

## Getting Started

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download).
2. Update the connection string in `FundooApp.API/appsettings.json` to match your SQL Server instance.
3. From the solution root:

```bash
dotnet restore
cd FundooApp.API
dotnet ef migrations add AddNotes --project ../FundooApp.RepositoryLayer --startup-project .
dotnet ef database update --project ../FundooApp.RepositoryLayer --startup-project .
cd ..
dotnet run --project FundooApp.API
```

4. Browse to `/swagger` to test.

> **Note:** the `Migrations` folder is intentionally not committed — each environment generates its own.

## Testing the flow

1. `POST /api/User/register`
2. `POST /api/User/login` → copy JWT
3. Click **Authorize** in Swagger, paste the raw token
4. `POST /api/Note` → create a note
5. `DELETE /api/Note/{noteId}` → delete it

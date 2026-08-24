# FundooApp — Day 15: Pin/Archive/Trash + Search & Filter

BridgeLabz Backend Refresher — .NET 20-Day Plan, **Day 15**: Entity Framework advanced patterns, CQRS, LINQ deep-dive.

Scope for this day (per training roadmap):
- Notes: Pin / Archive / Trash module
- Notes: Search & Filter module

## Project Structure

```
FundooApp/
├── FundooApp.sln
├── FundooApp.API/
│   └── Controllers/
│       ├── UserController.cs      # register, login, [Authorize] profile
│       └── NoteController.cs      # create, delete, pin/archive/trash, search & filter
├── FundooApp.BusinessLayer/
│   ├── Interfaces/
│   └── Services/
│       ├── UserBusiness.cs
│       └── NoteBusiness.cs        # commands + LINQ-backed queries
├── FundooApp.ModelLayer/
│   ├── DTOs/
│   ├── Entities/
│   │   ├── User.cs
│   │   └── Note.cs                # IsPin, IsArchive, IsTrash flags
│   └── Exceptions/
└── FundooApp.RepositoryLayer/
    ├── Context/
    ├── Interfaces/
    └── Repositories/
        ├── UserRepository.cs
        └── NoteRepository.cs      # CQRS-style: Commands vs Queries
```

## CQRS-style separation (Day 15 concept)

`INoteRepository` and `INoteBusiness` are split into two groups:

- **Commands** — `AddAsync`, `UpdateAsync`, `DeleteAsync`, and the new toggle operations (pin/archive/trash/restore). These mutate state.
- **Queries** — `GetByIdAsync`, `GetActiveNotesAsync`, `GetArchivedNotesAsync`, `GetTrashedNotesAsync`, `SearchAsync`. These are read-only and built with LINQ filters/ordering directly against the `DbContext`.

This isn't a full CQRS framework (no separate read/write databases or message bus) — it's the conceptual split your training day introduces: reads and writes are different concerns, expressed as different method groups.

## Notes Module Endpoints

| Method | Route                        | Description                              |
|--------|-------------------------------|-------------------------------------------|
| POST   | /api/Note                    | Create a note                             |
| DELETE | /api/Note/{noteId}           | Permanently delete a note                 |
| GET    | /api/Note                    | List active notes (not archived/trashed), pinned first |
| GET    | /api/Note/archived           | List archived notes                       |
| GET    | /api/Note/trash               | List trashed notes                        |
| GET    | /api/Note/search?query=...   | Search active notes by title/description  |
| PATCH  | /api/Note/{noteId}/pin       | Toggle pin on/off                         |
| PATCH  | /api/Note/{noteId}/archive   | Toggle archive on/off                     |
| PATCH  | /api/Note/{noteId}/trash     | Move note to trash (un-pins it too)       |
| PATCH  | /api/Note/{noteId}/restore   | Restore a note out of trash               |

All Notes endpoints are `[Authorize]`-protected and scoped to the logged-in user's own notes.

## Getting Started

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download).
2. Update the connection string in `FundooApp.API/appsettings.json`.
3. From the solution root:

```bash
dotnet restore
cd FundooApp.API
dotnet ef migrations add AddNotes --project ../FundooApp.RepositoryLayer --startup-project .
dotnet ef database update --project ../FundooApp.RepositoryLayer --startup-project .
cd ..
dotnet run --project FundooApp.API
```

> If you already applied a Notes migration on a previous day, EF will detect there's nothing new to migrate (this day only added query logic and toggle endpoints, not schema changes) - skip straight to `dotnet run`.

4. Browse to `/swagger`.

## Testing the flow

1. Register/login, authorize with the JWT.
2. `POST /api/Note` — create 2-3 notes.
3. `PATCH /api/Note/{id}/pin` — pin one, then `GET /api/Note` and confirm it sorts first.
4. `PATCH /api/Note/{id}/archive` — then check it disappears from `GET /api/Note` but appears in `GET /api/Note/archived`.
5. `PATCH /api/Note/{id}/trash` — check it disappears from active/archived and appears in `GET /api/Note/trash`.
6. `PATCH /api/Note/{id}/restore` — confirm it comes back to the active list.
7. `GET /api/Note/search?query=<part of a title>` — confirm it finds the right note.

## Unit Testing (Day 16 — MSTest)

Unit tests use **MSTest** + **Moq** (mocking repository interfaces) and **EF Core InMemory** (exercising real LINQ queries without SQL Server).

From the solution root:

```bash
dotnet test
```

Coverage:
- `FundooApp.Tests/BusinessLayer/UserBusinessTests.cs` — register (success + duplicate email), login (success + wrong password + nonexistent user), profile lookup (found + not-found)
- `FundooApp.Tests/BusinessLayer/NoteBusinessTests.cs` — create, delete (Day 14), pin/archive/trash/restore toggles, search fallback behavior (Day 15), label attach/detach/filter (Day 16)
- `FundooApp.Tests/BusinessLayer/LabelBusinessTests.cs` — create (success + duplicate name + trims whitespace), list, delete (success + not-found) (Day 16)
- `FundooApp.Tests/RepositoryLayer/NoteRepositoryTests.cs` — real LINQ query behavior: active/archived/trash filtering, pinned-first sorting, search matching on title and description, trash exclusion from search, label attach/detach/filter against a real (in-memory) many-to-many relationship
- `FundooApp.Tests/RepositoryLayer/LabelRepositoryTests.cs` — per-user isolation, case-insensitive duplicate-name checks, delete ownership checks

## Tags/Labels Management Module (Day 16)

A `Label` belongs to a user and can be attached to many notes (many-to-many, via an implicit `NoteLabels` join table). Label names are unique per user.

| Method | Route                              | Description                          |
|--------|--------------------------------------|----------------------------------------|
| POST   | /api/Label                         | Create a label                        |
| GET    | /api/Label                         | List the logged-in user's labels      |
| DELETE | /api/Label/{labelId}               | Delete a label (also detaches it from any notes) |
| POST   | /api/Note/{noteId}/labels/{labelId}| Attach a label to a note              |
| DELETE | /api/Note/{noteId}/labels/{labelId}| Remove a label from a note            |
| GET    | /api/Note/label/{labelId}          | List notes carrying a given label     |

`NoteResponseDTO` now includes a `labels` array (label names) on every note response, so note cards show their tags directly.

All endpoints are `[Authorize]`-protected. Labels and note-label associations are scoped so a user can only see/attach/remove their own labels on their own notes.

**Schema change this day**: adds `Labels` table and `NoteLabels` join table.
```bash
cd FundooApp.API
dotnet ef migrations add AddLabels --project ../FundooApp.RepositoryLayer --startup-project .
dotnet ef database update --project ../FundooApp.RepositoryLayer --startup-project .
```

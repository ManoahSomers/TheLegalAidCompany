# .NET WebAPI Code Challenge - TheLegalAidCompany

TheLegalAidCompany provides legal aid and legal-expenses insurance. This repository contains a .NET
10 WebAPI that exposes legal case operations for family law, contract disputes, and labor law.

## System requirements

- .NET 10 SDK (pinned via [global.json](global.json))
- Visual Studio 2022, JetBrains Rider, or VS Code
- Git

## Solution structure

- Main solution: [src/TheLegalAidCompany/TheLegalAidCompany.sln](src/TheLegalAidCompany/TheLegalAidCompany.sln)
- Interview materials: [interview/](interview/)

Layered architecture (dependencies point downward):

```
TLA.WebAPI
  -> TLA.DomainAPI
     -> TLA.ServiceAdapter.Cases
     -> TLA.ServiceAdapter.CRM
  -> TLA.DomainModel
```

Each layer keeps its own model contracts and maps between layers explicitly.
Dependency injection is configured in
[src/TheLegalAidCompany/TLA.WebAPI/Program.cs](src/TheLegalAidCompany/TLA.WebAPI/Program.cs) using
Scrutor assembly scanning.

## API operations

Base route pattern: `api/[controller]/[action]`

### AuthController

- `POST /api/Auth/GenerateToken` (anonymous)
  - Body: integer PPID (for example `1`)
  - Returns: JWT token string

### CaseController (requires bearer token)

- `POST /api/Case/GetCases`
  - Reads PPID from JWT claim
  - Returns case names for that customer
- `POST /api/Case/AddCase`
  - Adds a new case
- `POST /api/Case/DecideCase`
  - Sets a case coverage decision

### RelationController (requires bearer token)

- `GET /api/Relation/GetRelation`
  - Returns relation details from CRM stub
- `GET /api/Relation/GetPolicy`
  - Returns policy details from CRM stub

## Build and run

From [src/TheLegalAidCompany/](src/TheLegalAidCompany/):

```bash
dotnet build TheLegalAidCompany.sln
```

To run the WebAPI directly:

```bash
dotnet run --project TLA.WebAPI
```

Then open Swagger at the local URL shown by ASP.NET Core launch output.

## Tests

The repository includes unit tests for:

- Domain behavior: `TLA.DomainAPI.UnitTests`
- Service adapter behavior: `TLA.ServiceAdapter.UnitTests`

Example:

```bash
dotnet test TLA.ServiceAdapter.UnitTests
```

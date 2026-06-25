# Technical Interview Challenge – The Legal Aid Company

## Background

You are working on the backend system for **The Legal Aid Company (TLA)**, a platform that manages legal cases for customers. Each customer has a **policy** that defines what type of legal coverage they have and when that coverage is valid.

Before a new legal case can be registered in the system, the domain layer must verify that the customer's policy actually covers the type of case being submitted.

---

## Your Task

Implement the `AddCase` method in `TLA.Domain\Domain.cs`:

```csharp
public void AddCase(LegalCase legalCase)
{
    // TODO: implement
}
```

The method receives a `LegalCase` object and must:

1. **Retrieve the customer's policy** using the `policyProvider`, based on `legalCase.CustomerPpid`.
2. **Determine if the case is covered** by checking:
   - The policy's `EndDate` is today or in the future (the policy has not expired).
   - The policy's `CoverageType` matches the type of case being added (see mapping below).
3. **Set the `CoverageStatus`** on the `legalCase` accordingly:
   - `CoverageStatus.Covered` – if both conditions above are met.
   - `CoverageStatus.NotCovered` – if either condition is not met.
4. **Add the case** to the system by calling `caseProvider.AddCase(legalCase)`.

> **Note:** For now you do **not** need to handle any exceptions that may occur.

---

## Coverage Type Mapping

The policy's `CoverageType` (`CoverageTypes` enum from `TLA.ServiceAdapter.CRM`) must match the concrete type of the `LegalCase` being added:

| `CoverageTypes` value | Matching `LegalCase` subtype |
|-----------------------|------------------------------|
| `CoverageTypes.LaborLaw` | `LaborLawCase` |
| `CoverageTypes.FamilyLaw` | `FamilyLawCase` |
| `CoverageTypes.ContractDispute` | `ContractDisputeCase` |
| `CoverageTypes.None` | No case type is covered |

---

## Reference

### `LegalCase` (abstract base class)

```csharp
public abstract class LegalCase
{
    public int CustomerPpid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CaseFee { get; set; }
    public CoverageStatus CoverageStatus { get; set; } = CoverageStatus.Pending;
}
```

### Concrete case types

```csharp
public class LaborLawCase : LegalCase
{
    public decimal ClaimAmount { get; set; }
    public bool Settled { get; set; }
    public decimal SettlementAmount { get; set; }
}

public class FamilyLawCase : LegalCase
{
    public string CaseReference { get; set; }
    public int NumberOfHearings { get; set; }
    public DateTime FilingDate { get; set; }
}

public class ContractDisputeCase : LegalCase
{
    public IEnumerable<Jurisdiction>? Jurisdictions { get; set; }
    public decimal ClaimAmount { get; set; }
}
```

### `CoverageStatus` enum

```csharp
public enum CoverageStatus
{
    Pending = 0,
    Covered = 1,
    NotCovered = 2
}
```

### `IPolicyProvider` interface

```csharp
public interface IPolicyProvider
{
    Policy? GetPolicy(int relationId);
}
```

### `Policy` model (from `TLA.ServiceAdapter.CRM`)

```csharp
public class Policy
{
    public int Id { get; set; }
    public int RelationId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CoverageTypes CoverageType { get; set; }
}

public enum CoverageTypes
{
    None,
    FamilyLaw,
    ContractDispute,
    LaborLaw,
}
```

### `ICaseProvider` interface

```csharp
public interface ICaseProvider
{
    void AddCase(LegalCase legalCase);
    IEnumerable<LegalCase> GetCases(int customerPpid);
    void UpdateCoverage(string caseName, CoverageStatus decision);
}
```

### Available dependencies in `Domain`

The `Domain` class already has the following providers injected and available to use:

```csharp
public sealed class Domain(
    ICaseProvider caseProvider,
    IRelationProvider relationProvider,
    IPolicyProvider policyProvider) : IDomain
```

---

## Acceptance Criteria

- [ ] The customer's policy is retrieved using `policyProvider`.
- [ ] The `CoverageStatus` is set to `Covered` when the policy has not expired **and** the `CoverageType` matches the case type.
- [ ] The `CoverageStatus` is set to `NotCovered` when the policy has expired **or** the `CoverageType` does not match the case type.
- [ ] The case is always added by calling `caseProvider.AddCase(legalCase)`, regardless of coverage outcome.
- [ ] No exception handling is required.

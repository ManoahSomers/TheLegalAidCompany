using TLA.Common.Exceptions;
using TLA.ServiceAdapter.Cases.Models;

namespace TLA.ServiceAdapter.Cases.Stubs;

/// <summary>
/// DO NOT CHANGE - A simple in-memory database stub to simulate data storage and retrieval for legal cases. This is intended for test purposes only.
/// </summary>
public static class DatabaseStub
{
    private static readonly IList<LegalCase> Cases;

    static DatabaseStub()
    {
        Cases = new List<LegalCase>
        {
            new FamilyLawCase
            {
                CustomerPpid = 1,
                Name = "Divorce Settlement Smit",
                Description = "Contested divorce with division of assets",
                FilingDate = new DateTime(1993, 10, 13),
                CaseFee = 50m,
                CaseReference = "FAM-1993-0013",
                NumberOfHearings = 3,
                CoverageStatus = CoverageStatus.Covered
            },
            new ContractDisputeCase
            {
                CustomerPpid = 1,
                Name = "Dutch Supplier Breach",
                Jurisdictions = new List<Jurisdiction>
                {
                    new()
                    {
                        Code = "NL",
                        Name = "Netherlands"
                    }
                },
                Description = "Breach of a domestic supply contract",
                CaseFee = 20,
                ClaimAmount = 7000,
                CoverageStatus = CoverageStatus.Pending
            },
            new ContractDisputeCase
            {
                CustomerPpid = 2,
                Name = "Cross-Border Trade Dispute",
                Jurisdictions = new List<Jurisdiction>
                {
                    new()
                    {
                        Code = "DE",
                        Name = "Germany"
                    },
                    new()
                    {
                        Code = "ES",
                        Name = "Spain"
                    }
                },
                Description = "Dispute spanning several European jurisdictions",
                CaseFee = 20,
                ClaimAmount = 7000,
                CoverageStatus = CoverageStatus.Covered
            },
            new ContractDisputeCase
            {
                CustomerPpid = 2,
                Name = "US Licensing Conflict",
                Jurisdictions = new List<Jurisdiction>
                {
                    new()
                    {
                        Code = "US",
                        Name = "United States of America"
                    }
                },
                Description = "Litigating over there is expensive",
                CaseFee = 50,
                ClaimAmount = 25000,
                CoverageStatus = CoverageStatus.NotCovered
            },
            new LaborLawCase
            {
                CustomerPpid = 3,
                Name = "Wrongful Dismissal Jansen",
                Description = "Unfair dismissal claim < 2.5m",
                Settled = true,
                SettlementAmount = 500,
                CaseFee = 8,
                ClaimAmount = 2500000,
                CoverageStatus = CoverageStatus.Covered
            }
        };
    }

    public static void Add(LegalCase legalCase)
    {
        Cases.Add(legalCase);
    }

    public static void UpdateCoverage(string caseName, CoverageStatus decision)
    {
        var caseToUpdate = Cases.FirstOrDefault(c => c.Name == caseName);
        if (caseToUpdate != null)
            caseToUpdate.CoverageStatus = decision;
    }

    public static IEnumerable<LegalCase> GetAllCases()
    {
        if (new Random().Next(0, 20) == 0) // 5% chance to throw an exception
        {
            throw new TechnicalException("Connection to Cases datastore timed out.");
        }

        return Cases;
    }
}

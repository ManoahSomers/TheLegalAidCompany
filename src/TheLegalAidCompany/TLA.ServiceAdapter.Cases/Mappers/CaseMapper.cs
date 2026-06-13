using TLA.ServiceAdapter.Cases.Models;

namespace TLA.ServiceAdapter.Cases.Mappers;

public static class CaseMapper
{
    public static ICollection<DomainModel.LegalCase> Map(this IEnumerable<LegalCase> cases)
    {
        return cases.Select(legalCase => legalCase.Map()).ToList();
    }

    public static DomainModel.LegalCase Map(this LegalCase legalCase)
    {
        if (legalCase is FamilyLawCase familyLawCase)
        {
            return Map(familyLawCase);
        }
        if (legalCase is ContractDisputeCase contractDisputeCase)
        {
            return Map(contractDisputeCase);
        }
        if (legalCase is LaborLawCase laborLawCase)
        {
            return Map(laborLawCase);
        }

        throw new NotImplementedException();
    }

    private static DomainModel.FamilyLawCase Map(FamilyLawCase legalCase)
    {
        return new DomainModel.FamilyLawCase
        {
            CustomerPpid = legalCase.CustomerPpid,
            Name = legalCase.Name,
            Description = legalCase.Name,
            CaseFee = legalCase.CaseFee,
            CaseReference = legalCase.Name,
            NumberOfHearings = legalCase.NumberOfHearings,
            FilingDate = legalCase.FilingDate,
            CoverageStatus = (DomainModel.CoverageStatus)legalCase.CoverageStatus
        };
    }

    private static DomainModel.ContractDisputeCase Map(ContractDisputeCase legalCase)
    {
        return new DomainModel.ContractDisputeCase
        {
            CustomerPpid = legalCase.CustomerPpid,
            Name = legalCase.Name,
            Description = legalCase.Description,
            CaseFee = legalCase.CaseFee,
            Jurisdictions = MapJurisdictions(legalCase.Jurisdictions),
            ClaimAmount = legalCase.ClaimAmount,
            CoverageStatus = (DomainModel.CoverageStatus)legalCase.CoverageStatus
        };
    }

    private static IEnumerable<DomainModel.Jurisdiction>? MapJurisdictions(IEnumerable<Jurisdiction>? jurisdictions)
    {
        return jurisdictions?.Select(j => new DomainModel.Jurisdiction { Code = j.Code, Name = j.Name });
    }

    private static DomainModel.LaborLawCase Map(LaborLawCase legalCase)
    {
        return new DomainModel.LaborLawCase
        {
            CustomerPpid = legalCase.CustomerPpid,
            Name = legalCase.Name,
            Description = legalCase.Description,
            CaseFee = legalCase.CaseFee,
            ClaimAmount = legalCase.ClaimAmount,
            Settled = legalCase.Settled,
            SettlementAmount = legalCase.SettlementAmount,
            CoverageStatus = (DomainModel.CoverageStatus)legalCase.CoverageStatus
        };
    }
}

using TLA.WebAPI.Models;
using TLA.WebAPI.Models.Requests;

namespace TLA.WebAPI.Mappers;

internal static class AddCaseRequestMapper
{
    public static DomainModel.LegalCase Map(AddCaseRequest request)
    {
        if (request.FamilyLawCase != null)
        {
            return Map(request.FamilyLawCase);
        }
        if (request.ContractDisputeCase != null)
        {
            return Map(request.ContractDisputeCase);
        }
        if (request.LaborLawCase != null)
        {
            return Map(request.LaborLawCase);
        }

        return null;
    }

    private static DomainModel.FamilyLawCase Map(FamilyLawCase legalCase)
    {
        return new DomainModel.FamilyLawCase
        {
            Name = legalCase.Name,
            Description = legalCase.Name,
            CaseFee = legalCase.CaseFee,
            CaseReference = legalCase.Name,
            NumberOfHearings = legalCase.NumberOfHearings,
            FilingDate = legalCase.FilingDate,
            CoverageStatus = DomainModel.CoverageStatus.Pending
        };
    }

    private static DomainModel.ContractDisputeCase Map(ContractDisputeCase legalCase)
    {
        return new DomainModel.ContractDisputeCase
        {
            Name = legalCase.Name,
            Description = legalCase.Description,
            CaseFee = legalCase.CaseFee,
            Jurisdictions = MapJurisdictions(legalCase.Jurisdictions),
            ClaimAmount = legalCase.ClaimAmount,
            CoverageStatus = DomainModel.CoverageStatus.Pending
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
            Name = legalCase.Name,
            Description = legalCase.Description,
            CaseFee = legalCase.CaseFee,
            ClaimAmount = legalCase.ClaimAmount,
            Settled = legalCase.Settled,
            SettlementAmount = legalCase.SettlementAmount,
            CoverageStatus = DomainModel.CoverageStatus.Pending
        };
    }
}

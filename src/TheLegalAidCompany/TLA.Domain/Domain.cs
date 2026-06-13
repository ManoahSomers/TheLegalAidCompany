using TLA.DomainAPI.Models;
using TLA.DomainModel;
using TLA.DomainModel.Request;
using TLA.ServiceAdapter.Cases;
using TLA.ServiceAdapter.CRM;

namespace TLA.DomainAPI;

public sealed class Domain(
    ICaseProvider caseProvider,
    IRelationProvider relationProvider,
    IPolicyProvider policyProvider) : IDomain
{
    public IEnumerable<LegalCase> GetCases(GetCasesRequest getCasesRequest)
    {
        return caseProvider.GetCases(getCasesRequest.CustomerPpid);
    }

    public void AddCase(LegalCase legalCase)
    {
        caseProvider.AddCase(legalCase);
    }

    public IEnumerable<ContractDisputeCase> GetDutchContractDisputeCases()
    {
        return caseProvider.GetDutchContractDisputeCases();
    }

    public void DecideCoverage(string caseName, CoverageStatus decision)
    {
        caseProvider.UpdateCoverage(caseName, decision);
    }

    public Relation GetRelation(int ppid)
    {
        var relation = relationProvider.GetRelation(ppid)!;

        return new Relation
        {
            Id = relation.Id,
            LastName = relation.LastName,
            Initials = relation.Initials,
            Gender = relation.Gender,
            PhoneNumber = relation.PhoneNumber
        };
    }

    public Policy GetPolicy(int ppid)
    {
        var policy = policyProvider.GetPolicy(ppid)!;

        return new Policy
        {
            Id = policy.Id,
            RelationId = policy.RelationId,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate,
            Coverage = policy.Coverage.ToString()
        };
    }
}

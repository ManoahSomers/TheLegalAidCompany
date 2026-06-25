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

    // Implement the AddCase method to add a new legal case to the system
    // Get the policy for the customer and check if the coverage is active before adding the case
    public void AddCase(LegalCase legalCase)
    {

    }

    public void UpdateCoverage(string caseName, CoverageStatus decision)
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
            CoverageType = policy.CoverageType.ToString()
        };
    }
}

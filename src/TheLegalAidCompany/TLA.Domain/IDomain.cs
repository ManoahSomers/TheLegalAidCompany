using TLA.DomainAPI.Models;
using TLA.DomainModel;
using TLA.DomainModel.Request;

namespace TLA.DomainAPI;

public interface IDomain
{
    IEnumerable<LegalCase> GetCases(GetCasesRequest getCasesRequest);
    void AddCase(LegalCase legalCase);

    void UpdateCoverage(string caseName, CoverageStatus decision);

    Relation GetRelation(int ppid);
    
    Policy GetPolicy(int ppid);
}

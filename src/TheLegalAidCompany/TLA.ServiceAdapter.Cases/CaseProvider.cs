using TLA.ServiceAdapter.Cases.Mappers;
using TLA.ServiceAdapter.Cases.Models;
using TLA.ServiceAdapter.Cases.Stubs;

namespace TLA.ServiceAdapter.Cases;

public sealed class CaseProvider : ICaseProvider
{
    public void AddCase(DomainModel.LegalCase legalCase)
    {
        DatabaseStub.Add(new LaborLawCase());
    }

    public IEnumerable<DomainModel.LegalCase> GetCases(int customerPpid)
    {
        var cases = DatabaseStub.GetAllCases().Where(c => c.CustomerPpid == customerPpid);
        return cases.Map();
    }

    public void UpdateCoverage(string caseName, DomainModel.CoverageStatus decision)
    {
        DatabaseStub.UpdateCoverage(caseName, (CoverageStatus)decision);
    }
}

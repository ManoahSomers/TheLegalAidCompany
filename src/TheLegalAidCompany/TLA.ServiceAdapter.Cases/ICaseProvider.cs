namespace TLA.ServiceAdapter.Cases;

public interface ICaseProvider
{
    void AddCase(DomainModel.LegalCase legalCase);
    IEnumerable<DomainModel.LegalCase> GetCases(int customerPpid);
    void UpdateCoverage(string caseName, DomainModel.CoverageStatus decision);
}

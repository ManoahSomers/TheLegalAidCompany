namespace TLA.ServiceAdapter.Cases;

public interface ICaseProvider
{
    void AddCase(DomainModel.LegalCase legalCase);
    IEnumerable<DomainModel.LegalCase> GetCases(int customerPpid);
    IEnumerable<DomainModel.ContractDisputeCase> GetDutchContractDisputeCases();
    void UpdateCoverage(string caseName, DomainModel.CoverageStatus decision);
}

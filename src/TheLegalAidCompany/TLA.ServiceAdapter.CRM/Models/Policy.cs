namespace TLA.ServiceAdapter.CRM.Models;

public class Policy
{
    public int Id { get; set; }
    public int RelationId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CoverageTypes CoverageType { get; set;}
}

public enum CoverageTypes
{
    None,
    FamilyLaw,
    ContractDispute,
    LaborLaw,
}
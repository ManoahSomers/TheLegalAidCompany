namespace TLA.ServiceAdapter.CRM.Models;

public class Policy
{
    public int Id { get; set; }
    public int RelationId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Coverages Coverage { get; set;}
}

public enum Coverages
{
    None,
    FamilyLaw,
    ContractDispute,
    LaborLaw,
}
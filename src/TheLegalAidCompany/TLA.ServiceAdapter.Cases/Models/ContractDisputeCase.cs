namespace TLA.ServiceAdapter.Cases.Models;

public class ContractDisputeCase : LegalCase
{
    public IEnumerable<Jurisdiction>? Jurisdictions { get; set; }
    public decimal ClaimAmount { get; set; }
}

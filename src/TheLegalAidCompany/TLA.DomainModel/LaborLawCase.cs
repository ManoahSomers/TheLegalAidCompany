namespace TLA.DomainModel;

public class LaborLawCase : LegalCase
{
    public decimal ClaimAmount { get; set; }
    public bool Settled { get; set; }
    public decimal SettlementAmount { get; set; }
}

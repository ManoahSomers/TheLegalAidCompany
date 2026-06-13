namespace TLA.DomainModel;

public abstract class LegalCase
{
    public int CustomerPpid { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CaseFee { get; set; }
    public CoverageStatus CoverageStatus { get; set; } = CoverageStatus.Pending;
}

namespace TLA.DomainAPI.Models;

public class Policy
{
    public int Id { get; set; }
    public int RelationId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CoverageType { get; set; }
}

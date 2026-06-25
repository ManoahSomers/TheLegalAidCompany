namespace TLA.WebAPI.Models.Requests;

public class UpdateCoverageRequest
{
    public string CaseName { get; set; }
    public CoverageStatus Decision { get; set; }
}

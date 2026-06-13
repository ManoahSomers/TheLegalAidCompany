namespace TLA.WebAPI.Models.Requests;

public class DecideCoverageRequest
{
    public string CaseName { get; set; }
    public CoverageStatus Decision { get; set; }
}

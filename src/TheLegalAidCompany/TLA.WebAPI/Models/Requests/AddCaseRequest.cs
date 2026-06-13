
namespace TLA.WebAPI.Models.Requests;

public class AddCaseRequest
{
    public ContractDisputeCase? ContractDisputeCase { get; set; }

    public FamilyLawCase? FamilyLawCase { get; set; }

    public LaborLawCase? LaborLawCase { get; set; }
}

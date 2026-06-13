namespace TLA.WebAPI.Models.Responses;

public class GetRelationResponse
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Coverage { get; set; }
}

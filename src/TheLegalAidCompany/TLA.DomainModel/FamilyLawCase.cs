namespace TLA.DomainModel;

public class FamilyLawCase : LegalCase
{
    public string CaseReference { get; set; }

    public int NumberOfHearings { get; set; }

    public DateTime FilingDate { get; set; }
}

using TLA.ServiceAdapter.CRM.Models;
using TLA.Common.Exceptions;

namespace TLA.ServiceAdapter.CRM.Stubs;

/// <summary>
/// DO NOT CHANGE - This is a stub class to simulate CRM.
/// </summary>
public static class CrmStub
{
    private static readonly IList<Relation> _relations;
    private static readonly IList<Policy> _policies;

    static CrmStub()
    {
        _relations = new List<Relation>
        {
            new Relation
            {
                Id = 1,
                LastName = "Smith",
                Initials = "J.D.",
                Gender = "Male",
                PhoneNumber = "123-456-7890"
            },
            new Relation
            {
                Id = 2,
                LastName = "Doe",
                Initials = "A.B.",
                Gender = "Female",
                PhoneNumber = "987-654-3210"
            },
            new Relation
            {
                Id = 3,
                LastName = "Johnson",
                Initials = "C.E.",
                Gender = "Male",
                PhoneNumber = "555-555-5555"
            }
        };

        _policies = new List<Policy>
        {
            new Policy
            {
                Id = 1,
                RelationId = 1,
                StartDate = DateTime.Now.AddMonths(-6),
                EndDate = DateTime.Now.AddMonths(6),
                Coverage = Coverages.FamilyLaw
            },
            new Policy
            {
                Id = 2,
                RelationId = 2,
                StartDate = DateTime.Now.AddMonths(-3),
                EndDate = DateTime.Now.AddMonths(9),
                Coverage = Coverages.ContractDispute
            },
            new Policy
            {
                Id = 3,
                RelationId = 3,
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now.AddMonths(11),
                Coverage = Coverages.LaborLaw
            }
        };
    }

    public static Relation GetRelationById(int id)
    {
        if (id <= 0)
        {
            throw new FunctionalException("ID is invalid.");
        }

        if (new Random().Next(0, 5) == 0) // 20% chance to throw an exception => this is generous, SAP is more unreliable than that.
        {
            throw new TechnicalException("Connection to CRM timed out.");
        }

        return _relations.FirstOrDefault(r => r.Id == id) ?? throw new FunctionalException($"Relation with ID {id} not found.");
    }

    public static Policy GetPolicyByRelationId(int relationId)
    {
        if (relationId <= 0)
        {
            throw new FunctionalException("Relation ID is invalid.");
        }

        if (new Random().Next(0, 10) == 0) // 10% chance to throw an exception
        {
            throw new TechnicalException("Connection to CRM timed out.");
        }

        return _policies.FirstOrDefault(p => p.RelationId == relationId) ?? throw new FunctionalException($"Policy for Relation ID {relationId} not found.");
    }
}

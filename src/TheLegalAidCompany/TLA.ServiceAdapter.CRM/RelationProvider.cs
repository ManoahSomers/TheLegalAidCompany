using TLA.ServiceAdapter.CRM.Models;
using TLA.ServiceAdapter.CRM.Stubs;

namespace TLA.ServiceAdapter.CRM;

public sealed class RelationProvider : IRelationProvider
{
    public Relation? GetRelation(int id)
    {
        return CrmStub.GetRelationById(id);
    }
}

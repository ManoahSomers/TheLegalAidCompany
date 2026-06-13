using TLA.ServiceAdapter.CRM.Models;

namespace TLA.ServiceAdapter.CRM;

public interface IRelationProvider
{
    Relation? GetRelation(int id);
}

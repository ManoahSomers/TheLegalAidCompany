using TLA.ServiceAdapter.CRM.Models;
using TLA.ServiceAdapter.CRM.Stubs;

namespace TLA.ServiceAdapter.CRM;

public sealed class PolicyProvider : IPolicyProvider
{
    public Policy? GetPolicy(int relationId)
    {
        return CrmStub.GetPolicyByRelationId(relationId);
    }
}

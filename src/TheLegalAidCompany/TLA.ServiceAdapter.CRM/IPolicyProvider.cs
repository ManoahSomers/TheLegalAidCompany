using TLA.ServiceAdapter.CRM.Models;

namespace TLA.ServiceAdapter.CRM;

public interface IPolicyProvider
{
    Policy? GetPolicy(int relationId);  
}
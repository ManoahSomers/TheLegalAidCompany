using TLA.WebAPI.Models.Requests;

namespace TLA.WebAPI.Mappers;

internal static class GetCasesRequestMapper
{
    public static DomainModel.Request.GetCasesRequest Map(int customerPpid)
    {
        return new DomainModel.Request.GetCasesRequest { CustomerPpid = customerPpid };
    }
}

using TLA.DomainModel;
using TLA.WebAPI.Models.Responses;

namespace TLA.WebAPI.Mappers.Impl;

internal static class GetCasesResponseMapper
{
    public static GetCasesResponse Map(IEnumerable<LegalCase> cases)
    {
        return new GetCasesResponse
        {
            Name = cases.Select(c => c.Name)
        };
    }
}

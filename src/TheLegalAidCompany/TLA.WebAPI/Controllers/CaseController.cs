using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TLA.DomainAPI;
using TLA.WebAPI.Mappers;
using TLA.WebAPI.Mappers.Impl;
using TLA.WebAPI.Models.Requests;
using TLA.WebAPI.Models.Responses;

namespace TLA.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public sealed class CaseController(
    IDomain caseDomain
    ) : ControllerBase
{

    [HttpPost(nameof(GetCases))]
    public GetCasesResponse GetCases()
    {
        var ppid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var domainRequest = GetCasesRequestMapper.Map(ppid);
        var cases = caseDomain.GetCases(domainRequest);
        var mappedResponse = GetCasesResponseMapper.Map(cases);
        return mappedResponse;
    }

    [HttpPost(nameof(AddCase))]
    public void AddCase(AddCaseRequest request)
    {

    }

    [HttpPost(nameof(UpdateCoverage))]
    public void UpdateCoverage(UpdateCoverageRequest request)
    {
        caseDomain.UpdateCoverage(request.CaseName, (DomainModel.CoverageStatus)request.Decision);
    }
}

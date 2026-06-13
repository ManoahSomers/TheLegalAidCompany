using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TLA.DomainAPI;
using TLA.WebAPI.Models.Responses;

namespace TLA.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public sealed class RelationController(IDomain domain) : ControllerBase
{
    [HttpGet(nameof(GetRelation))]
    public GetRelationResponse GetRelation()
    {
        var ppid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var relation = domain.GetRelation(ppid);
        return new GetRelationResponse
        {
            Id = relation!.Id,
            LastName = relation.LastName,
            Initials = relation.Initials,
            Gender = relation.Gender,
            PhoneNumber = relation.PhoneNumber
        };
    }

    [HttpGet(nameof(GetPolicy))]
    public GetPolicyResponse GetPolicy()
    {
        var ppid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var policy = domain.GetPolicy(ppid);
        return new GetPolicyResponse
        {
            Id = policy!.Id,
            RelationId = policy.RelationId,
            StartDate = policy.StartDate,
            EndDate = policy.EndDate,
            Coverage = policy.Coverage.ToString()
        };
    }
}

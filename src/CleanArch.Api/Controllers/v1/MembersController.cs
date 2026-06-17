using CleanArch.Api.Contracts.Member.Requests;
using CleanArch.Application.Features.Member.Commands.CreateMember;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class MembersController(ISender sender) : BaseController
{
    /// <summary>
    /// Post action for create member
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateMemberRequest request, CancellationToken ct)
    {
        var command = request.Adapt<CreateMemberCommand>();
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }
}
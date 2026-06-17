using CleanArch.Api.Contracts.Member.Requests;
using CleanArch.Application.Features.Member.Commands.BlockMember;
using CleanArch.Application.Features.Member.Commands.CreateMember;
using CleanArch.Application.Features.Member.Commands.UnblockMember;

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

    /// <summary>
    /// Post action for block member
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost("{id:guid}/Block")]
    public async Task<IActionResult> Block(Guid id, CancellationToken ct)
    {
        var command = new BlockMemberCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }

    /// <summary>
    /// Post action for unblock member
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost("{id:guid}/Unblock")]
    public async Task<IActionResult> Unblock(Guid id, CancellationToken ct)
    {
        var command = new UnblockMemberCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }
}
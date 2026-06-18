using CleanArch.Api.Contracts.Member.Requests;
using CleanArch.Api.Contracts.Member.Responses;
using CleanArch.Application.Features.Member.Commands.BlockMember;
using CleanArch.Application.Features.Member.Commands.CreateMember;
using CleanArch.Application.Features.Member.Commands.UnblockMember;
using CleanArch.Application.Features.Member.Commands.UpdateMember;
using CleanArch.Application.Features.Member.Common;
using CleanArch.Application.Features.Member.Queries.GetMemberById;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class MembersController(ISender sender) : BaseController
{
    /// <summary>
    /// Get action for get member by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var query = new GetMemberByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToActionResult<MemberDto, GetMemberByIdResponse>();
    }

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
    /// Put action for update member
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMemberRequest request, CancellationToken ct)
    {
        var command = new UpdateMemberCommand(id, request.FirstName, request.LastName, request.Email);
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
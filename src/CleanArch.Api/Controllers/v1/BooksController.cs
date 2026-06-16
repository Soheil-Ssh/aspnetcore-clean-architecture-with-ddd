using CleanArch.Api.Contracts.Book.Requests;
using CleanArch.Api.Contracts.Book.Responses;
using CleanArch.Application.Features.Book.Commands.CreateBook;
using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.Features.Book.Queries.GetBookById;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class BooksController(ISender sender) : BaseController
{
    /// <summary>
    /// Get action for get book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var query = new GetBookByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToActionResult<BookDto, GetBookByIdResponse>();
    }

    /// <summary>
    /// Post action for create book
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request, CancellationToken ct)
    {
        var command = request.Adapt<CreateBookCommand>();
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }
}
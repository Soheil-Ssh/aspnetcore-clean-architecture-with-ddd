using CleanArch.Api.Contracts.Book.Requests;
using CleanArch.Api.Contracts.Book.Responses;
using CleanArch.Application.Features.Book.Commands.CreateBook;
using CleanArch.Application.Features.Book.Commands.CreateBookCopy;
using CleanArch.Application.Features.Book.Commands.UpdateBook;
using CleanArch.Application.Features.Book.Common;
using CleanArch.Application.Features.Book.Queries.GetBookById;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
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

    /// <summary>
    /// Put action for update book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBookRequest request, CancellationToken ct)
    {
        var command = new UpdateBookCommand(id, request.Title, request.Author, request.Publisher, request.Isbn, request.PublishYear);
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }

    /// <summary>
    /// Post action create book copy
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost("CreateCopy/{id:guid}")]
    public async Task<IActionResult> CreateCopy([FromRoute] Guid id, [FromBody] CreateBookCopyRequest request,
        CancellationToken ct)
    {
        var command = new CreateBookCopyCommand(id, request.Barcode);
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }
}
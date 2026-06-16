using CleanArch.Api.Contracts.Book.Requests;
using CleanArch.Application.Features.Book.Commands.CreateBook;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class BooksController(ISender sender) : BaseController
{
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
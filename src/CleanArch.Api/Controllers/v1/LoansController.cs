using CleanArch.Api.Contracts.Loan.Requests;
using CleanArch.Application.Features.Loan.Commands.CreateLoan;

namespace CleanArch.Api.Controllers.v1;

[ApiVersion(1)]
public class LoansController(ISender sender) : BaseController
{
    /// <summary>
    /// Post action for create loan
    /// </summary>
    /// <param name="request"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateLoanRequest request, CancellationToken ct)
    {
        var command = request.Adapt<CreateLoanCommand>();
        var result = await sender.Send(command, ct);
        return result.ToActionResult();
    }
}
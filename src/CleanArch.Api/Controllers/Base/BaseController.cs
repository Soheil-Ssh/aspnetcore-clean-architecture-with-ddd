namespace CleanArch.Api.Controllers.Base;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
public class BaseController : ControllerBase;
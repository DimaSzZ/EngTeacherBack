using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngTeacher.Controllers.Auth;

[ApiController]
[Route("api/auth")]
[Authorize]
public class AuthController : BaseController
{
    [HttpPost("AddFriend")]
    public async Task<IActionResult> AddToFriend(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost("WriteMess")]
    public async Task<IActionResult> WriteMessage(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("GetAllFollowers")]
    public async Task<IActionResult> GetAllFollowers(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("GetOneFollower")]
    public async Task<IActionResult> GetOneFollower(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost("SetAvatarForUser")]
    public async Task<IActionResult> SetAvatarForUser(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("GetDetailUser")]
    public async Task<IActionResult> GetDetailUser(CancellationToken cancellationToken)
    {
        return Ok();
    }
    
}
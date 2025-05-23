#if DEBUG
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using SkiStore.Api.DTOs;
using SkiStore.Core.Entities;

namespace SkiStore.Api.Controllers;

// Experimental controller to help testing error handling, don't remove pre-processor if DEBUG.
public class _BuggyController : BaseApiController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized()
    {
        return Unauthorized(new
        {
            Error = "401 Unauthorized",
            Description = "The HTTP 401 Unauthorized client error response status code indicates that a request was not successful because it lacks valid authentication credentials for the requested resource. This status code is sent with an HTTP WWW-Authenticate response header that contains information on the authentication scheme the server expects the client to include to make the request successfully.",
            Docs = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/401"
        });
    }

    [HttpGet("bad-request")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new
        {
            Error = "400 Bad Request",
            Description = "The HTTP 400 Bad Request client error response status code indicates that the server would not process the request due to something the server considered to be a client error. The reason for a 400 response is typically due to malformed request syntax, invalid request message framing, or deceptive request routing.",
            Docs = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400"
        });
    }

    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        return NotFound(new
        {
            Error = "404 Not Found",
            Description = "The HTTP 404 Not Found client error response status code indicates that the server cannot find the requested resource. Links that lead to a 404 page are often called broken or dead links and can be subject to link rot.",
            Docs = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404"
        });
    }

    [HttpGet("internalerror")]
    public IActionResult GetInternalError()
    {
        throw new Exception("Test exception");
    }

    [HttpPost("validationerror")]
    public IActionResult GetValidationError(CreateProductDTO product)
    {
        return Ok();
    }

    [Authorize] // Protection at endpoint level.
    // [AllowAnonymous] Allow unauthenticated requests even in a protected controller.
    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        var name = User.FindFirst(ClaimTypes.Name)?.Value;
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok("Hello " + name + " with the id of " + id);
    }
}
#endif

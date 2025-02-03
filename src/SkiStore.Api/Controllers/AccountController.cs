using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiStore.Api.DTOs;
using SkiStore.Api.Extensions;
using SkiStore.Core.Entities;
using SkiStore.Core.Interfaces;

namespace SkiStore.Api.Controllers;

public class AccountController(SignInManager<AppUser> signInManager) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDTO registerDTO) 
    {
        var user = new AppUser
        {
            FirstName = registerDTO.FirstName,
            LastName = registerDTO.LastName,
            Email = registerDTO.Email,
            UserName = registerDTO.Email
        };

        var result = await signInManager.UserManager.CreateAsync(user, registerDTO.Password);

        // if (!result.Succeeded) return BadRequest(result.Errors);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }

    // [Authorize]
    [HttpGet("user-info")]
    public async Task<ActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated == false) return NoContent();
        
        // var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

        var user = await signInManager.UserManager.GetUserByEmail(User);

        return Ok(new 
        {
            user.FirstName,
            user.LastName,
            user.Email
        }); 
    }

    [HttpGet]
    public ActionResult GetAuthState()
    {
        return Ok(new 
        {
            IsAuthenticated = User.Identity?.IsAuthenticated ?? false
        });
    }
}

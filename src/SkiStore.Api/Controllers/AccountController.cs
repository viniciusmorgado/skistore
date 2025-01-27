using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkiStore.Api.DTOs;
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
            UserName = registerDTO.Email,

        };

        var result = await signInManager.UserManager.CreateAsync(user, registerDTO.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok();
    }
}

using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Entities;

namespace SkiStore.Api.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        return await userManager.Users.FirstOrDefaultAsync(x => x.Email == user.GetEmail()) ?? 
        throw new AuthenticationException("User not found!");
    }

    public static string GetEmail(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.Email) ??
        throw new AuthenticationException("Email claim not found!");
    }
}

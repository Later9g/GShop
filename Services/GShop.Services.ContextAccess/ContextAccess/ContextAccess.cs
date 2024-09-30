using GShop.Context.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GShop.Services.ContextAccess;

public class ContextAccess : IContextAccess
{
    private readonly UserManager<User> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;

    public ContextAccess(UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor
        )
    {
        this.userManager = userManager;
        this.httpContextAccessor = httpContextAccessor;
    }
    public async Task<User> GetCurrentUser()
    {
        var userClaim = httpContextAccessor.HttpContext?.User;

        if (userClaim == null || !userClaim.Identity.IsAuthenticated)
        {
            throw new InvalidOperationException("No user is currently logged in.");
        }

        var userId = userClaim.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new InvalidOperationException("User ID claim not found.");
        }

        var user = await userManager.FindByIdAsync(userId);
        return user ?? throw new InvalidOperationException("User not found.");
    }

}

namespace GShop.Identity.Configuration;

using GShop.Common.Security;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.GadgetWrite, "Write")
        };
}
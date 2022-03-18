using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Notes.Identity;

public class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("CleanNotes", "CleanNotes")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("CleanNotes", "CleanNotes",
                new[] {JwtClaimTypes.Name})
            {
                Scopes = {"CleanNotes"}
            }
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "clean-notes",
                ClientName = "Clean Notes",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris = {"http://.../signin-oidc"},
                AllowedCorsOrigins = {"http://..."},
                PostLogoutRedirectUris = {"http:/.../signout-oidc"},
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "CleanNotes"
                },
                AllowAccessTokensViaBrowser = true
            }
        };
}
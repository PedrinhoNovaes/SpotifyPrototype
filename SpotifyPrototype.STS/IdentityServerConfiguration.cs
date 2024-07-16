using IdentityServer4.Models;
using IdentityServer4;

namespace SpotifyPrototype.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId() {},
                new IdentityResources.Profile() {},
            };
        }

        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("SpotifyPrototype", "SpotifyPrototype", new string[] { "SpotifyPrototype" })
                {
                    ApiSecrets =
                    {
                        new Secret("SpotifyPrototype".Sha256())
                    },
                    Scopes =
                    {
                        "SpotifyPrototypeScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope()
                {
                    Name = "SpotifyPrototypeScope",
                    DisplayName = "SpotifyPrototypeScope API",
                    UserClaims = { "SpotifyPrototypeScope" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "client-angular-SpotifyPrototype",
                    ClientName = "Acesso do front as apis",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SpotifyPrototypeScope".Sha256())
                        {

                        }
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotifyPrototypeScope"
                    }
                }
            };
        }
    }
}

using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public static class Configuration
    {
        // identity token
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
              new List<IdentityResource>
              {
                  new IdentityResources.OpenId(),
                  new IdentityResources.Profile(),
                  new IdentityResource
                  {
                      Name = "rc.scope",
                      UserClaims = 
                      {
                        "rc.grandma"
                      }
                  }
              };

        // access token
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> 
            {
                new ApiResource("HomeBudget.API", new string [] { "rc.api.grandma" }),
            };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope("HomeBudget.API", "HomeBudget.Service")
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientName = "Home Manager App",

                    // Todo:  the secret simply being hashed using an extension method provided by IdentityServer. 
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    

                    //AllowedGrantTypes = GrantTypes.ClientCredentials, // machine to machine communication
                    AllowedGrantTypes = GrantTypes.Code,    // user to machine communication ?

                    RedirectUris = { "https://localhost:44363/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44363/Home/Index" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "HomeBudget.API",
                        //"homeBudget.api.read",
                        //"homeBudget.api.write",

                        "rc.scope"
                    },

                    // puts all the claims in the id token
                    //AlwaysIncludeUserClaimsInIdToken = true,

                    AllowOfflineAccess = true,
                    RequireConsent = false,
                    
                }
            };



    }
}

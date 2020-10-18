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
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
              new List<IdentityResource>
              {
                  new IdentityResources.OpenId(),
                  new IdentityResources.Profile(),
              };

        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> 
            {
                new ApiResource("HomeBudget.API")
            };

        public static IEnumerable<ApiScope> GetScopes() =>
            new List<ApiScope>
            {
                new ApiScope("HomeBudget.API", "HomeBudget.Service")
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    

                    //AllowedGrantTypes = GrantTypes.ClientCredentials, // machine to machine communication
                    AllowedGrantTypes = GrantTypes.Code,    // user to machine communication ?

                    RedirectUris = { "https://localhost:44363/signin-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "HomeBudget.API"
                    },

                    RequireConsent = false,
                    
                }
            };



    }
}

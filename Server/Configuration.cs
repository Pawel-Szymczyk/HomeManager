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
                  //new IdentityResources.Email(),
                  //new IdentityResource
                  //{
                  //    Name = "rc.scope",
                  //    UserClaims = 
                  //    {
                  //      "rc.grandma"
                  //    }
                  //}
                  new IdentityResource
                  {
                      Name = "role",
                      UserClaims =
                      {
                        "role"
                      }
                  }
              };

        // access token
        //public static IEnumerable<ApiResource> GetApiResources() =>
        //    new List<ApiResource> 
        //    {
        //        //new ApiResource("HomeBudget.API", new string [] { "rc.api.grandma" }),
        //        new ApiResource
        //        {
        //            Name = "homeBudget.api",
        //            DisplayName = "Home Budget API",
        //            Description = "Allow the application to access Home Budget API on your behalf",
        //            Scopes = new List<string> { "homeBudget.api.read", "homeBudget.api.write" },
        //            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        //            UserClaims = new List<string> {"role"}
        //        }
        //    };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                //new ApiScope("HomeBudget.API", "HomeBudget.Service")
                new ApiScope("homeBudget.api.read", "Read Access to Home Budget API"),
                new ApiScope("homeBudget.api.write", "Write Access to Home Budget API")
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
                        //"HomeBudget.API",
                        "homeBudget.api.read",
                        "homeBudget.api.write",

                        //"rc.scope"
                    },

                    // puts all the claims in the id token
                    //AlwaysIncludeUserClaimsInIdToken = true,

                    AllowOfflineAccess = true,
                    RequireConsent = false,
                    
                }
            };



    }
}

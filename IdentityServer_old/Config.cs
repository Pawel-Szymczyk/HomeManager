using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("PCBuilder.API", "PC Builder API."),
                new ApiScope("Test.API", "My API"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // api client
                //new Client
                //{
                //    ClientId = "client",

                //    // no interactive user, use the clientid/secret for authentication
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,

                //    // secret for authentication 
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    //scopes that client has access to
                //    AllowedScopes =
                //    {
                //        "api1",
                //    }
                //},

                // mvc
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    // where to redirect to after login
                //    RedirectUris = { "https://localhost:44317/signin-oidc" },

                //    // where to redirect to after logout
                //    PostLogoutRedirectUris = { "https://localhost:44317/signout-callback-oidc" },

                //    AllowOfflineAccess = true,

                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //         "PCBuilder.API",
                //         "Test.API",
                //    }
                //},

                //new Client
                //{
                //    ClientId = "blazor",
                //    AllowedGrantTypes = GrantTypes.Code,

                //    RequirePkce = true,
                //    RequireClientSecret = false,
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //         //"PCBuilder.API",
                //         //"Test.API",
                //    },
                //    AllowedCorsOrigins = { "https://localhost:44332/" },
                //    RedirectUris = { "https://localhost:44332/signin-oidc" },
                //    PostLogoutRedirectUris = { "https://localhost:44332/signout-callback-oidc" }
                //}
                new Client
                {
                    ClientId = "blazor",

                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedCorsOrigins = { "https://localhost:44307" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                         //"PCBuilder.API",
                         //"Test.API",
                    },
                    RedirectUris = { "https://localhost:44307/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:44307/authentication/logout-callback" },
                    Enabled = true
                }
            };

        

        //// identity token
        //public static IEnumerable<IdentityResource> GetIdentityResources() =>
        //      new List<IdentityResource>
        //      {
        //          new IdentityResources.OpenId(),
        //          new IdentityResources.Profile(),
        //          //new IdentityResources.Email(),

        //          // identitfy user
        //          new IdentityResource
        //          {
        //              Name = "rc.scope",
        //              UserClaims =
        //              {
        //                "rc.grandma"
        //              }

        //          }
        //      };

        //// use it to protect api
        //public static IEnumerable<ApiResource> GetApiResources() =>
        //    new List<ApiResource>
        //    {
        //        new ApiResource("Test.API"),
        //    };


        ////A scope is a logical name for (a part of) functionality of the resource. 
        ////So a resource without scopes would mean that the resource has no functionality.
        //public static IEnumerable<ApiScope> GetScopes() =>
        //     new List<ApiScope>
        //     {
        //         new ApiScope("Test.API"),
        //     };


        //public static IEnumerable<Client> GetClients() =>
        //    new List<Client>
        //    {
        //        new Client
        //        {
        //            ClientId = "client-id-some-guid",

        //            // secret for authentication
        //            ClientSecrets =
        //            {
        //                new Secret("client_secret".Sha256())
        //            },

        //            // no interactive user, use the clientid/secret for authentication
        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44317/signin-oidc" },


        //            // scopes that client has access to
        //            AllowedScopes = new List<string>
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                "Test.API",
        //                "rc.scope"
        //            },

        //            AllowOfflineAccess = true,
        //            RequireConsent = false,

                   
                   
        //        }
        //    };
    }
}

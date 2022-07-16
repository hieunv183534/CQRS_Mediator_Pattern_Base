using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityProvider
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                 new Client {
                    RequireConsent = false,
                    ClientId = "angular_spa",
                    ClientName = "Angular SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api1.read", "api1.write" },
                    RedirectUris = { "http://localhost:4200/public/auth-callback", "https://vnpost.ddns.net/kt1/public/auth-callback"},
                    PostLogoutRedirectUris = {"http://localhost:4200/", "https://vnpost.ddns.net/kt1/"},
                    AllowedCorsOrigins = {"http://localhost:4200", "https://vnpost.ddns.net"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                 },
                 new Client {
                         ClientName = "Client Mobile",
                         ClientId = "huokgu&549^nb)(*3s23#4",
                         AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                         ClientSecrets = { new Secret("eb601de6-ydc4-34u2-g4ug-abd3c72h4019".Sha256()) },
                         AllowedScopes = { "openid", "profile", "email", "api1.read", "api1.write" }
                 }
            };
        }
    }

    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "Web Api KT1",
                    Description = "Hệ thống api của ứng dụng KT1",
                    Scopes = new List<string> {"api1.read", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())}, // change me!
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1.read", "Read Access to API #1"),
                new ApiScope("api1.write", "Write Access to API #1")
            };
        }
    }

    //internal class Users
    //{
    //    public static List<TestUser> Get()
    //    {
    //        return new List<TestUser>
    //        {
    //            new TestUser
    //            {
    //                SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
    //                Username = "admin",
    //                Password = "Password123!",
    //                Claims = new List<Claim>
    //                {
    //                    new Claim(JwtClaimTypes.Email, "admin@gmail.com"),
    //                    new Claim(JwtClaimTypes.Role, "admin")
    //                }
    //            }
    //        };
    //    }
    //}
}

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer
{
    public static class Config
    {
        //authserver hangi apilerden sorumlu
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api")
                {
                    Scopes={ "api1.read", "api1.write", "api1.update" },
                    ApiSecrets= new[]{new Secret("secretapi1".Sha256())}
                },
                new ApiResource("resource_api2")
                {
                    Scopes={ "api2.read", "api2.write", "api2.update" },
                    ApiSecrets= new[]{new Secret("secretapi2".Sha256())}
                }
            };
        } 
        //bu apiler hangi izinlere sahip olacak
        public static IEnumerable<ApiScope> GetApiScope()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","Api1 için okuma izni"),
                new ApiScope("api1.write","Api1 için yazma izni"),
                new ApiScope("api1.update","Api1 için güncelleme izni"), 
                new ApiScope("api2.read","Api2 için okuma izni"),
                new ApiScope("api2.write","Api2 için yazma izni"),
                new ApiScope("api2.update","Api2 için güncelleme izni"),
             
            };
        }
        //bu apileri hangi client'lar kullanacak
      

        // identity resoruce kimlikle alakalı bilgiler tutulacak
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                // bunlar claimler tutar
                new IdentityResources.OpenId(), //subid
                new IdentityResources.Profile(), //
            };
        }
        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser{SubjectId="1",Username="onuryurt",Password="password",Claims= new List<Claim>(){
                    new Claim("given_name","Onur"),
                    new Claim("family_name","Yurt") }}, 
                new TestUser{SubjectId="2",Username="ahmet16",Password="password",Claims= new List<Claim>(){
                    new Claim("given_name","Ahmet"),
                    new Claim("family_name","Özdemir") }},

            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId ="Client1",
                    ClientName ="Client 1 app Uygulaması",
                    ClientSecrets = new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read"}

                },
                  new Client()
                {
                    ClientId ="Client2",
                    ClientName ="Client 2 app Uygulaması",
                    ClientSecrets = new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read","api1.update" ,"api2.write","api2.update"}

                },
                  new Client()
                  {
                      ClientId = "Client1-Mvc",
                      RequirePkce=false, //clientsecret güvenli tutuyorum.
                      ClientName ="Client 1 mvc app Uygulaması",
                      ClientSecrets = new[] {new Secret("secret".Sha256())},
                      AllowedGrantTypes = GrantTypes.Hybrid,
                      RedirectUris= new List<string>{ "https://localhost:5003/signin-OIdCookies" }, //bu url token alma işlemini gerçekleştirir.
                      AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId,
                          IdentityServerConstants.StandardScopes.Profile}
                  }

            };
        }
    }
}

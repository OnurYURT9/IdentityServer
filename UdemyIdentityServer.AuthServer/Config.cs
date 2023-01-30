using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new ApiResource("resource_api"){ Scopes={ "api1.read", "api1.write", "api1.update" } },
                new ApiResource("resource_api2"){Scopes={ "api2.read", "api2.write", "api2.update" }}
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
                    AllowedScopes={"api1.read" ,"api2.write","api2.update"}

                }
            };
        }

        
    }
}

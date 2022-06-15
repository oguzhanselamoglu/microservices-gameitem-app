﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Identity.Api
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_order"){Scopes={"orderapi"}},
            new ApiResource("resource_store"){Scopes={"storeapi"}},
       
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name="CompanyId", DisplayName="CompanyId", Description="Company Id", UserClaims=new []{ "companyId"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
              new ApiScope[]
            {
                new ApiScope("orderapi","Order Api"),
                new ApiScope("storeapi","Store Api"),
      
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientName="Api Client",
                    ClientId="ApiClient",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={ "orderapi", "storeapi", IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                    ClientName="Game Client",
                    ClientId="adminclient",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowOfflineAccess=true,
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "orderapi", "storeapi", IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName},
                    AccessTokenLifetime=1*60*30,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(30)- DateTime.Now).TotalSeconds,
                    RefreshTokenUsage= TokenUsage.ReUse
                }           
            };
    }
}
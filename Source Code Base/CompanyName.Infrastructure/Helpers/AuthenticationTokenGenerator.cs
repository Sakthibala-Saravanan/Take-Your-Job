﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace AspireSystems.Infrastructure.Helpers
{
    /// <summary>
    /// Authentication Token generating helper
    /// </summary>
    public static class AuthenticationTokenGenerator
    {
        public static string GetUserName(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDecoded = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var dictionary = tokenDecoded.Claims.ToDictionary(c => c.Type, c => c.Value);
            var userName = !string.IsNullOrEmpty(dictionary["username"]) ? dictionary["username"] : "";
            return userName;
        }
    }
}

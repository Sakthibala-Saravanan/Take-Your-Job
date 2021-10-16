using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Threading;
using AspireSystems.Infrastructure.Models;

namespace AspireSystems.Infrastructure.Authentication.Helpers
{
    public static class TokenValidator
    {
        /// <summary>
        /// Validates the user's authentication token
        /// </summary>
        public static bool ValidateToken(string token, AppSettings appSettings)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token", "token should not be null");
            }
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
                rsa.ImportParameters(
                  new RSAParameters()
                  {
                      Modulus = FromBase64Url(appSettings.PublicKeyModulus),
                      Exponent = FromBase64Url(appSettings.PublicKeyExponent)
                  });

                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };

                var principal = new JwtSecurityTokenHandler()
                  .ValidateToken(token, validationParameters, out var rawValidatedToken);
                Thread.CurrentPrincipal = principal;             
                return principal.Identity.IsAuthenticated;
            }
            catch (SecurityTokenValidationException)
            {
                return false;
            }
        }

        static byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                  .Replace("-", "+");
            return Convert.FromBase64String(base64);
        }
    }
}

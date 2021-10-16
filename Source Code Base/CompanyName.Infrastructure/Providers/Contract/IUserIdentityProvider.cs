using System.Linq;
using AspireSystems.Infrastructure.Helpers;

namespace AspireSystems.Infrastructure.Providers
{
    public interface IUserIdentityProvider
    {
        string UserId { get; }

        string UserName { get; }

        string FirstName { get; }

        string[] Roles { get; }

        string[] Privileges { get; }
    }

    public class AspireSystemsUserIdentityProvider : IUserIdentityProvider
    {
        public string UserId
        {
            get
            {
                return GetClaims("UserId");
            }
        }

        public string UserName
        {
            get
            {
                return GetClaims("UserName");
            }
        }

        public string FirstName
        {
            get
            {
                return GetClaims("FirstName");
            }
        }

        public string[] Roles
        {
            get
            {
                return GetClaimsArray("role");
            }
        }

        public string[] Privileges
        {
            get
            {
                return GetClaimsArray("Privileges");
            }
        }
        
        private static string GetClaims(string claimType)
        {
            if (HttpContext.Current != null)
            {
                var claimsList = HttpContext.Current.User.Identities.SelectMany(x => x.Claims);
                var claim = claimsList.FirstOrDefault(x => x.Type.Equals(claimType));
                if (claim != null)
                {
                    var Username = claim.Value;
                    return Username;
                }
                else { return string.Empty; }
            }
            else { return string.Empty; }
        }

        private static string[] GetClaimsArray(string claimType)
        {
            if (HttpContext.Current != null)
            {
                var claimsList = HttpContext.Current.User.Identities.SelectMany(x => x.Claims);
                var claim = claimsList.FirstOrDefault(x => x.Type.Equals(claimType));
                if (claim != null)
                {
                    var roles = claim.Value;
                    var array = roles.Split(",");
                    return array;
                }
                else { return new string[] { }; }
            }
            else { return new string[] { }; }
        }
    }

}
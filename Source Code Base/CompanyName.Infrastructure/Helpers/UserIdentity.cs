using System;
using System.Linq;
using AspireSystems.Infrastructure.Providers;

namespace AspireSystems.Infrastructure.Helpers
{
    public static class UserIdentity
    {
        private static IUserIdentityProvider _provider;

        public static void Configure(IUserIdentityProvider provider)
        {
            _provider = provider;
        }

        public static string UserId
        {
            get
            {
                return _provider.UserId;
            }
        }
        public static string UserName
        {
            get
            {
                return _provider.UserName;
            }
        }
        public static string FirstName
        {
            get
            {
                return _provider.FirstName;
            }
        }
        public static string[] Roles
        {
            get
            {
                return _provider.Roles;
            }
        }
      
        public static string[] Privileges
        {
            get
            {
                return _provider.Privileges;
            }
        }

        /// <summary>
        /// Verifies the user has the specific role
        /// </summary>
        public static bool HasRole(string roleName)
        {
            return Roles.Contains(roleName);
        }
        /// <summary>
        /// Verifies the user has the specific privilege
        /// </summary>
        public static bool HasPrivilege(string privilegeName)
        {
            return Privileges.Contains(privilegeName);
        }

        public static string RandomPassword()
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "0123456789";
            string specialCharacters = "*#&@";
            string randomPassword = string.Empty;
            Random random = new Random();
            for (int i = 1; i <= 4; i++)
                randomPassword = randomPassword.Insert(random.Next(randomPassword.Length), lowers[random.Next(lowers.Length - 1)].ToString());
            for (int i = 1; i <= 1; i++)
                randomPassword = randomPassword.Insert(random.Next(randomPassword.Length), uppers[random.Next(uppers.Length - 1)].ToString());
            for (int i = 1; i <= 2; i++)
                randomPassword = randomPassword.Insert(random.Next(randomPassword.Length), number[random.Next(number.Length - 1)].ToString());
            for (int i = 1; i <= 1; i++)
                randomPassword = randomPassword.Insert(random.Next(randomPassword.Length), specialCharacters[random.Next(specialCharacters.Length - 1)].ToString());
            return randomPassword;
        }
    }

    public static class HttpContext
    {
        private static Microsoft.AspNetCore.Http.IHttpContextAccessor m_httpContextAccessor;
        public static void Configure(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            m_httpContextAccessor = httpContextAccessor;
        }
        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                return m_httpContextAccessor.HttpContext;
            }
        }

    }


}

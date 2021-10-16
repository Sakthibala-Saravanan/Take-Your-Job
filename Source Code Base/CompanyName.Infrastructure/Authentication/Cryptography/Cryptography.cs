using System;
using System.Security.Cryptography;
using System.Text;
using AspireSystems.Infrastructure.Authentication.Cryptography.Contracts;

namespace AspireSystems.Infrastructure.Authentication.Cryptography
{
    /// <summary>
    /// Represents the class for providing encryption and decryption
    /// </summary>
    public class Cryptography : ICryptography
    {
        #region Public Methods
        /// <summary>
        /// Encrypts the password
        /// </summary>
        /// <returns></returns>
        public string Encrypt(string password, string key)
        {
            ICryptoTransform ct = GetEncryptor(key);
            byte[] input = Encoding.Unicode.GetBytes(password);
            return Convert.ToBase64String(ct.TransformFinalBlock(input, 0, input.Length));
        }
        /// <summary>
        /// Decrypts the password
        /// </summary>
        public string Decrypt(string encryptedPassword, string key)
        {
            byte[] b = Convert.FromBase64String(encryptedPassword);
            ICryptoTransform ct = GetDecryptor(key);
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);

        }
        #endregion

        #region Private Methods
        private ICryptoTransform GetDecryptor(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            using(var aes = new AesCryptoServiceProvider())
            {
                aes.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
                aes.IV = new byte[aes.BlockSize / 8];
                return aes.CreateDecryptor();
            }
        }

        private ICryptoTransform GetEncryptor(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
                aes.IV = new byte[aes.BlockSize / 8];
                return aes.CreateEncryptor();
            }
        }
        #endregion
    }
}

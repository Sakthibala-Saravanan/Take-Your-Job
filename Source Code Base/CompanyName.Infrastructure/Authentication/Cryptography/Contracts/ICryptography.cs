namespace AspireSystems.Infrastructure.Authentication.Cryptography.Contracts
{
    /// <summary>
    /// Represents interface for passord encryption and decryption
    /// </summary>
    public interface ICryptography
    {
        /// <summary>
        /// Encrypts the passord
        /// </summary>
        string Encrypt(string password, string key);
        /// <summary>
        /// Decrypts the password
        /// </summary>
        string Decrypt(string encryptedPassword, string key);
    }
}

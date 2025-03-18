using System.Security.Cryptography;
using System.Text;
using Texter_App.Runtime;

namespace Texter_App.Util.Encryption;
public static class AesEncryption
{
    // Encrypts the plain data using the provided key.
    // The key must be 16, 24, or 32 bytes long.
    // The output contains the IV prepended to the ciphertext.

    // Derive a valid AES key from a passphrase
    private static byte[] DeriveKey(string passphrase, int keyBytes = 32)
    {
        // Salt should be unique and stored/shared securely.
        byte[] salt = Encoding.UTF8.GetBytes(RuntimeConfigs.Salt);
        using (var keyDerivationFunction = new Rfc2898DeriveBytes(passphrase, salt, 10000, HashAlgorithmName.SHA512))
        {
            return keyDerivationFunction.GetBytes(keyBytes);
        }
    }
    public static byte[] Encrypt(byte[] plainData, byte[] key)
    {
        using (Aes aes = Aes.Create())
        {
            key = DeriveKey(RuntimeConfigs.Passphrase);
            aes.Key = key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.GenerateIV(); // Create a new IV for each message

            using (var ms = new MemoryStream())
            {
                // Write the IV at the beginning of the stream.
                ms.Write(aes.IV, 0, aes.IV.Length);

                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainData, 0, plainData.Length);
                    cs.FlushFinalBlock();
                }
                return ms.ToArray();
            }
        }
    }

    // Decrypts the cipher data using the provided key.
    // Expects the cipher data to have the IV prepended.
    public static byte[] Decrypt(byte[] cipherData, byte[] key)
    {
        using (Aes aes = Aes.Create())
        {
            key = DeriveKey(RuntimeConfigs.Passphrase);
            aes.Key = key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            int ivLength = aes.BlockSize / 8; // AES block size in bytes (typically 16)
            byte[] iv = new byte[ivLength];
            Array.Copy(cipherData, 0, iv, 0, ivLength);
            aes.IV = iv;

            using (var ms = new MemoryStream())
            {
                // Decrypt the remaining ciphertext (after the IV)
                using (var cs = new CryptoStream(new MemoryStream(cipherData, ivLength, cipherData.Length - ivLength),
                                                  aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.CopyTo(ms);
                }
                return ms.ToArray();
            }
        }
    }
}

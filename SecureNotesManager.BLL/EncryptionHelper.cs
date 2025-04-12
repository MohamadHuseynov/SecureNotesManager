using System.Security.Cryptography;
using System.Text;

namespace SecureNotesManager.BLL
{
    public static class EncryptionHelper
    {
        private static readonly string _key = "12345678901234567890123456789012"; // ۳۲ کاراکتر 


        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.GenerateIV();

            ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

            byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
            Array.Copy(aes.IV, result, aes.IV.Length);
            Array.Copy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] fullCipher = Convert.FromBase64String(encryptedText);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_key);

            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - 16];
            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor();
            byte[] decryptedBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}

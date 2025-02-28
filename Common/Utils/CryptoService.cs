using System.Security.Cryptography;
using System.Text;

namespace Common.Utils
{
    public class CryptoService
    {
        private static readonly byte[] IV = new byte[16] { 240, 3, 45, 29, 0, 76, 173, 59, 99, 150, 201, 78, 182, 33, 57, 204 };
        private const string cryptoKey = "U1N2F3V4E5R6P7";
        public static string Decrypt(string? encryptedQueryString)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(encryptedQueryString);
                using (Aes aes = Aes.Create())
                {
                    aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(cryptoKey));
                    aes.IV = IV;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(cryptoKey));
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}

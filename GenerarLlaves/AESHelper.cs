using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GenerarLlaves
{
    public class AESHelper
    {
        public static void GenerarClaveYIV(out string key, out string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256; // AES-256
                aes.GenerateKey();
                aes.GenerateIV();

                key = Convert.ToBase64String(aes.Key);
                iv = Convert.ToBase64String(aes.IV);
            }
        }

        public static string Encriptar(string plainText, string key, string iv)
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] ivBytes = Convert.FromBase64String(iv);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
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
}

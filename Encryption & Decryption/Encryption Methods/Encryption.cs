using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption___Decryption.Global_Classes;

namespace Encryption___Decryption.Encryption_Methods
{
    public static class clsEncryption
    {
        public static string BasicEncryption(string OriginalText)
        {
            StringBuilder DecryptedText = new StringBuilder();

            foreach (char c in OriginalText)
                DecryptedText.Append((char)(c + clsKeys.Key));

            return DecryptedText.ToString();
        }

        public static string SymmetricEncrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clsKeys.Key128);

                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

    }
}

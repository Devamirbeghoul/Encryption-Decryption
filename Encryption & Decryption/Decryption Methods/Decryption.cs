using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption___Decryption.Global_Classes;

namespace Encryption___Decryption.Decryption_Methods
{
    public static class clsDecryption
    {
        public static string BasicDecryption(string DecryptedText)
        {
            StringBuilder OriginalText = new StringBuilder();

            foreach (char c in DecryptedText)
                OriginalText.Append((char)(c - clsKeys.Key));

            return OriginalText.ToString();
        }

        public static string SymmetricDecrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clsKeys.Key128);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
             
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        
    }
}

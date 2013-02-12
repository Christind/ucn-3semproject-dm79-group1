using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Helpers
{
    public static class EncryptionHelper
    {
        private static string ByteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }

            return output.ToString();
        }

        public static string Sha256Encrypt(string phrase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256Hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256Hasher.ComputeHash(encoder.GetBytes(phrase));

            return ByteArrayToString(hashedDataBytes);
        }

        public static string Sha512Encrypt(string phrase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA512Managed sha512Hasher = new SHA512Managed();
            byte[] hashedDataBytes = sha512Hasher.ComputeHash(encoder.GetBytes(phrase));

            return ByteArrayToString(hashedDataBytes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChatAPI.Utils
{
    public static class Cryptography
    {
        private static SHA256 sha;

        public static string CalculateHash(string input)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] outputBytes = sha.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        public static byte[] CalculateHash(byte[] input)
        {
            return sha.ComputeHash(input);      
        }

        public static string ApplyShiftedXor(string input, string key)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] passBytes = Convert.FromBase64String(key);

            byte[] encrypted = applyShiftedXor(inputBytes, passBytes);

            return Convert.ToBase64String(encrypted);
        }

        public static string Encrypt(string input, string key)
        {
            return null;
        }

        public static string Decrypt(string input, string key)
        {
            return null;
        }

        private static byte[] applyShiftedXor(byte[] input, byte[] pass, ushort shift=7)
        {
            byte[] output = new byte[input.Length];
            for (int i = 0, j = 0; i < input.Length; i++, j = (i+shift) % pass.Length)
            {
                output[i] = (byte)(input[i] ^ pass[j]);
            }
            return output;
        }
    }
}

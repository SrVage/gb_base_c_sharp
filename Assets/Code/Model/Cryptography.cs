using System;

namespace Code
{
    public static class Cryptography
    {
        public static string CryptoXOR(string text, int key = 13)
        {
            var result = string.Empty;
            foreach (var symbol in text)
            {
                result += (char) ((symbol+1)*key);
            }
            return result;
        }

        public static string DeCryptoXOR(string text, int key = 13)
        {
            var result = string.Empty;
            foreach (var symbol in text)
            {
                result += (char) ((symbol/key)-1);
            }
            return result;
        }
        
    }
}
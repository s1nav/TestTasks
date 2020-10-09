using System;
using System.Collections.Generic;

namespace Cipher
{
    public sealed class Vigenere : IVigenere
    {
        private readonly string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        public string DefaultAlphabet { get => defaultAlphabet; }


        public string Encrypt(string source, string key)
        {
            return Crypt(source, key, true);
        }

        public string Decrypt(string encrypted, string key)
        {
            return Crypt(encrypted, key, false);
        }
        
        public IEnumerable<string> Encrypt(IEnumerable<string> source, string key)
        {
            var result = new List<string>();

            foreach (var s in source)
            {
                result.Add(Crypt(s, key, true));
            }

            return result;
        }

        public IEnumerable<string> Decrypt(IEnumerable<string> encrypted, string key)
        {
            var result = new List<string>();

            foreach (var e in encrypted)
            {
                result.Add(Crypt(e, key, false));
            }

            return result;
        }


        private string GetFullFilledKey(string key, int length)
        {
            while (key.Length < length)
            {
                key += key;
            }

            return key.Substring(0, length);
        }

        private string Crypt(string source, string key, bool encrypt)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"Key cannot be null!");
            }

            var fullFilledKey = GetFullFilledKey(key, source.Length);
            var result = "";

            for (int i = 0; i < source.Length; i++)
            {
                var sourceIndex = defaultAlphabet.IndexOf(source[i], StringComparison.CurrentCultureIgnoreCase);
                var cryptedIndex = defaultAlphabet.IndexOf(fullFilledKey[i], StringComparison.CurrentCultureIgnoreCase);

                if (sourceIndex < 0)
                {
                    throw new ArgumentException($"Input string contains invalid characters!");
                }

                if (encrypt)
                {
                    result += defaultAlphabet[(sourceIndex + cryptedIndex) % defaultAlphabet.Length].ToString();
                }
                else
                {
                    result += defaultAlphabet[(sourceIndex + defaultAlphabet.Length - cryptedIndex) % defaultAlphabet.Length].ToString();
                }
            }

            return result;
        }
    }
}

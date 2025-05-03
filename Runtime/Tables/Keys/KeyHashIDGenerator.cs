using System;
using System.Security.Cryptography;
using System.Text;

namespace UnityEngine.Localization.Tables {

    public class KeyHashIDGenerator : IKeyGenerator {

        public long GetHash(string key) {

            // Ensure the input key is valid
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key), "Key cannot be null or empty");

            // Create a hash from the input string
            using (var hashAlgorithm = SHA256.Create())
            {
                byte[] hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(key));

                // Convert the first 8 bytes of the hash into a long value
                return BitConverter.ToInt64(hashBytes, 0);
            }

        }

    }

}

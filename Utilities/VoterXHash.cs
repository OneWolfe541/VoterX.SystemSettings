using System;
using System.Security.Cryptography;
using System.Text;
namespace VoterX.SystemSettings.Utilities
{
    // https://stackoverflow.com/questions/12185122/calculating-hmacsha256-using-c-sharp-to-match-payment-provider-example
    public class VoterXHash
    {
        private string KEY;

        private string SALT;

        private string MESSAGE;

        public VoterXHash()
        {
            GenerateTheKey("KEY");
        }

        public VoterXHash(string key)
        {
            GenerateTheKey(key);
        }

        private void GenerateTheKey(string value)
        {
            KEY = HashEncode(HashHMAC(StringEncode("11/06/2018"), StringEncode(value)));
        }

        public string GenerateHash(string message)
        {
            MESSAGE = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(message)));
            return HashEncode(HashHMAC(StringEncode(KEY), StringEncode(MESSAGE)));
        }

        public string GenerateHash(string message, int iterations)
        {
            MESSAGE = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(message)));
            var result = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(MESSAGE)));

            for (int i = 0; i < iterations; i++)
            {
                result = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(result)));
            }

            return result;
        }

        public string GenerateHash(string message, string salt)
        {
            MESSAGE = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(message)));
            SALT = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(salt)));
            return HashEncode(HashHMAC(StringEncode(KEY), StringEncode(SALT + MESSAGE)));
        }

        public string GenerateHash(string message, string salt, int iterations)
        {
            MESSAGE = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(message)));
            SALT = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(salt)));
            var result = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(SALT + MESSAGE)));

            for (int i = 0; i < iterations; i++)
            {
                result = HashEncode(HashHMAC(StringEncode(KEY), StringEncode(result)));
            }

            return result;
        }

        private static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}

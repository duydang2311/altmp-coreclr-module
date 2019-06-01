using System.Security.Cryptography;
using System.Text;

namespace AltV.Net.NetworkingEntity
{
    public static class SecretToken
    {
        private const string CharSet =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789?=:;_+*ß.,<>%$§!&()^°@€-";

        public static string GenerateToken(int size)
        {
            var chars = CharSet.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString();
        }
    }
}
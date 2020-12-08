using System.Security.Cryptography;
using System.Text;

namespace Util.Cryptograph
{
    public static class Crypt
    {
        public static string PasswordEncript(string senha)
        {
            var algoritmo = SHA512.Create();
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = algoritmo.ComputeHash(encodedValue);
            var sb = new StringBuilder();

            foreach (var caracter in encryptedPassword)
                sb.Append(caracter.ToString("X4"));

            return sb.ToString();
        }

        public static bool PasswordVerify(string passwordDigited, string passwordDb)
        {
            var algoritmo = SHA512.Create();
            var encryptedPassword = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(passwordDigited));
            var sb = new StringBuilder();

            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X4"));
            }

            return sb.ToString().Equals(passwordDb);
        }
    }
}

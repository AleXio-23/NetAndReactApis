using System.Security.Cryptography;

namespace NorthernLight.Auth.Shared.Services
{
    public static class PasswordGenerator
    {
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()-_=+[]{};:,<.>/?";

        public static string GenerateSecurePassword(int length)
        {
            if (length < 4) throw new ArgumentException("Password length must be at least 4 characters.", nameof(length));

            var characterSet = UppercaseLetters + LowercaseLetters + Digits + SpecialCharacters;
            var passwordChars = new char[length];
            var randomBytes = new byte[length * 4]; // Using 4 bytes per character

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            for (int i = 0; i < length; i++)
            {
                // Convert the 4 bytes into a 32-bit integer and use it to pick a character
                uint randomNum = BitConverter.ToUInt32(randomBytes, i * 4);
                long index = randomNum % characterSet.Length;
                passwordChars[i] = characterSet[(int)index];
            }

            // Ensure the password contains at least one character from each category
            passwordChars[0] = UppercaseLetters[new Random().Next(UppercaseLetters.Length)];
            passwordChars[1] = LowercaseLetters[new Random().Next(LowercaseLetters.Length)];
            passwordChars[2] = Digits[new Random().Next(Digits.Length)];
            passwordChars[3] = SpecialCharacters[new Random().Next(SpecialCharacters.Length)];

            // Shuffle the array to randomize the positions of the ensured characters
            return ShuffleArray(passwordChars);
        }

        private static string ShuffleArray(char[] array)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                int n = array.Length;
                while (n > 1)
                {
                    byte[] box = new byte[1];
                    do rng.GetBytes(box);
                    while (!(box[0] < n * (byte.MaxValue / n)));
                    int k = box[0] % n;
                    n--;
                    (array[n], array[k]) = (array[k], array[n]);
                }
            }
            return new string(array);
        }
    }
}

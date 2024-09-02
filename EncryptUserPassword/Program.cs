namespace EncryptUserPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string plainPassword1 = "5p3ctrum";
            string plainPassword2 = "5p3ctrum";

            string encryptedPassword1 = BCrypt.Net.BCrypt.HashPassword(plainPassword1);
            string encryptedPassword2 = BCrypt.Net.BCrypt.HashPassword(plainPassword2);

            Console.WriteLine($"Encrypted password for Guose: {encryptedPassword1}");
            Console.WriteLine($"Encrypted password for K-rad: {encryptedPassword2}");
        }
    }
}

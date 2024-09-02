namespace DigitalBallotPlatform.Platform.Helpers
{
    public class UserPasswordEncryption
    {
        private readonly string password;

        public UserPasswordEncryption(string password)
        {
            this.password = password;
        }
        public string HashPassword => EncryptPassword(password);

        private string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

namespace Euronet.System.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryDurationMinutes { get; set; }

        public string Password { get; set; }
    }

}

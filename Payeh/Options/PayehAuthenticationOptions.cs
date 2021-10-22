namespace Payeh.Options
{
    public class PayehAuthenticationOptions 
    {

        public bool Enabled { get; set; } = true;
        
        public PayehAuthenticationJwtOptions Jwt { get; set; }
        
    }
    public class PayehAuthenticationJwtOptions 
    {

        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
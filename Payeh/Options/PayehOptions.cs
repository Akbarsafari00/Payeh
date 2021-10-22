namespace Payeh.Options
{
    public class PayehOptions 
    {
        public string Name { get; set; } 
        public string Version { get; set; }
        public PayehServiceOptions Services { get; set; }
        public PayehSwaggerOptions Swagger { get; set; }
        public PayehCorsOptions Cors { get; set; }
        public PayehAuthorizationOptions Authorization { get; set; }
        public PayehAuthenticationOptions Authentication { get; set; }
    }
}
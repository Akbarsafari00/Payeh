using System;

namespace Payeh.Options
{
    public class PayehServiceTranslatorOptions 
    {
        public string Type { get; set; }
        public PayehServiceTranslatorGoogleOptions Google { get; set; }
       
    }
    public class PayehServiceTranslatorGoogleOptions 
    {
        public string ApiKey { get; set; }
    }
}
namespace Payeh.Options
{
    public class PayehSwaggerOptions 
    {

        public bool Enabled { get; set; } = true;
        public PayehSwaggerDocOptions SwaggerDoc { get; set; } = new PayehSwaggerDocOptions();
    }

    public class PayehSwaggerDocOptions
    {
        
        public string Version { get; set; } = "v1";
        public string Description { get; set; } = "";
        public string Title { get; set; } = "My Application Title";
        public string Name { get; set; } = "v1";
        public string Url { get; set; } = "/swagger/v1/swagger.json";
    }
}
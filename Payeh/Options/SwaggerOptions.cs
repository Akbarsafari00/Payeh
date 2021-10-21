namespace Payeh.Options
{
    public class SwaggerOptions 
    {

        public bool Enabled { get; set; } = true;
        public SwaggerDocOptions SwaggerDoc { get; set; } = new SwaggerDocOptions();
    }

    public class SwaggerDocOptions
    {
        
        public string Version { get; set; } = "v1";
        public string Title { get; set; } = "My Application Title";
        public string Name { get; set; } = "v1";
        public string Url { get; set; } = "/swagger/v1/swagger.json";
    }
}
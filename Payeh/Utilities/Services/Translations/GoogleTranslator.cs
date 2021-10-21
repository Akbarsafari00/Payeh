using Google.Cloud.Translation.V2;
using Payeh.Options;

namespace Payeh.Utilities.Services.Translations
{
    public class GoogleTranslator : ITranslator
    {
        private readonly TranslationClient client;
        private readonly PayehOptions _options;
        

        public GoogleTranslator(PayehOptions options)
        {
            _options = options;
            client = TranslationClient.CreateFromApiKey(_options.Services.Translator.Google.ApiKey);
        }
        public    string this[string text , string lang]  => client.TranslateHtml(text,lang).TranslatedText; 
    }
}
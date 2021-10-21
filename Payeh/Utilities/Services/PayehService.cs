using Payeh.Utilities.Services.Logger;
using Payeh.Utilities.Services.Translations;

namespace Payeh.Utilities.Services
{
    public class PayehService : IPayehService 
    {
        public ILogger Logger { get; set; }
        public ITranslator Translator { get; set; }

        public PayehService(ILogger logger,ITranslator translator)
        {
            Logger = logger;
            Translator = translator;
        }
    }
}
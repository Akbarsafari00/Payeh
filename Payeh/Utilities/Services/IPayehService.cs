using Payeh.Utilities.Services.Logger;
using Payeh.Utilities.Services.Translations;

namespace Payeh.Utilities.Services
{
    public interface IPayehService
    {
        ILogger Logger { get; set; }
        ITranslator Translator { get; set; }
    }
}
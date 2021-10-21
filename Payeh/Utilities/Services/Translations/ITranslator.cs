namespace Payeh.Utilities.Services.Translations
{
    public interface ITranslator
    {
        string this[string text , string lang]
        {
            get;
        }
    }
}

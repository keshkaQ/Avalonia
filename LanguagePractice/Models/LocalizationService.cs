using System.Collections.Generic;

namespace LanguagePractice.Models;

public record LangCode(string? nameLanguage);
public class LocalizationService
{
    private readonly IReadOnlyDictionary<LangCode, IReadOnlyDictionary<string, string>> _translations;

    public LocalizationService()
    {
        _translations = DictionaryTranslator.GetTranslations();
    }
    
    public IReadOnlyDictionary<LangCode, IReadOnlyDictionary<string, string>> GetTranslations()
    {
        return _translations;
    }
    
}
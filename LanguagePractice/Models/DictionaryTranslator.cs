using System.Collections.Generic;

namespace LanguagePractice.Models;

public abstract class DictionaryTranslator
{
    public static IReadOnlyDictionary<LangCode, IReadOnlyDictionary<string, string>> GetTranslations()
    {
        var english = new LangCode("English");
        var russian = new LangCode("Русский");
        
        var translations = new Dictionary<LangCode, IReadOnlyDictionary<string, string>>
        {
            [english] = new Dictionary<string, string>
            {
                ["Welcome"] = "Welcome",
                ["Simple Button"] = "Simple Button",
                ["Choose Language:"] = "Choose Language:",
                ["Translate:"] = "Translate:",
                ["Добро пожаловать!"] = "Welcome",
                ["Просто кнопка"] = "Simple Button",
                ["Выберите язык:"] = "Choose Language:",
                ["Перевести:"] = "Translate:"
            },
            
            [russian] = new Dictionary<string, string>
            {
                ["Welcome"] = "Добро пожаловать!",
                ["Simple Button"] = "Просто кнопка",
                ["Choose Language:"] = "Выберите язык:",
                ["Translate:"] = "Перевести:",
                ["Добро пожаловать!"] = "Добро пожаловать!",
                ["Просто кнопка"] = "Просто кнопка",
                ["Выберите язык:"] = "Выберите язык:",
                ["Перевести:"] = "Перевести:"
            }
        };
        return translations;
    }
}
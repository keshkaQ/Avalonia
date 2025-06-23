using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using LanguagePractice.Models;

namespace LanguagePractice.ViewModels;

public partial class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly LocalizationService _localizationService = new();
    private string _welcomeText = "Добро пожаловать!";
    private string _buttonText = "Просто кнопка";
    private string _languageSelectionText = "Выберите язык:";
    private string _translateButtonText = "Перевести:";
    
    private ComboBoxItem? _selectedLanguageItem;
    public ComboBoxItem? SelectedLanguageItem
    {
        get => _selectedLanguageItem;
        set
        {
            if (_selectedLanguageItem != value)
            {
                _selectedLanguageItem = value;
                OnPropertyChanged();
                Translate();
            }
        }
    }
    
    public string WelcomeText
    {
        get => _welcomeText;
        set
        {
            _welcomeText = value;
            OnPropertyChanged();
        }
    }
    
    public string ButtonText
    {
        get => _buttonText;
        set
        {
            _buttonText = value;
            OnPropertyChanged();
        }
    }
    
    public string LanguageSelectionText
    {
        get => _languageSelectionText;
        set
        {
            _languageSelectionText = value;
            OnPropertyChanged();
        }
    }
    
    public string TranslateButtonText
    {
        get => _translateButtonText;
        set
        {
            _translateButtonText = value;
            OnPropertyChanged();
        }
    }

    private void Translate()
    {
        var langCode = new LangCode(nameLanguage:SelectedLanguageItem?.Content?.ToString());
        var translations = _localizationService.GetTranslations();
        if (translations.TryGetValue(langCode, out var languageTranslations))
        {
            WelcomeText = GetTranslation(languageTranslations, WelcomeText);
            ButtonText = GetTranslation(languageTranslations, ButtonText);
            LanguageSelectionText = GetTranslation(languageTranslations, LanguageSelectionText);
            TranslateButtonText = GetTranslation(languageTranslations, TranslateButtonText);
        }
    }
    private string GetTranslation(IReadOnlyDictionary<string, string> translations, string originalText)
    {
        return translations.GetValueOrDefault(originalText, originalText);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
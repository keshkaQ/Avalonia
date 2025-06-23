using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using ConvertСurrency.Models;

namespace ConvertCurrency.ViewModels;

public partial class MainWindowViewModel : INotifyPropertyChanged
{
    public ComboBoxItem SelectedMyCurrency { get; set; }
    public ComboBoxItem DesiredCurrency { get; set; }
    public RelayCommand ConvertMoneyCommand { get;set; }

    private string? valute;

    public string Valute
    {
        get { return valute; }
        set
        {
            valute = value;
            OnPropertyChanged();
        }
    }
    
    
    private readonly CurrencyService _currencyService = new();
    private string _sourceMoney;

    public string SourceMoney
    {
        get => _sourceMoney;
        set
        {
            _sourceMoney = value;
            OnPropertyChanged();
        }
    }
    private decimal _possibleMoney;

    public decimal PossibleMoney
    {
        get => _possibleMoney;
        set
        {
            _possibleMoney = value;
            OnPropertyChanged();
        }
    }
    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }
    public MainWindowViewModel()
    {
        ConvertMoneyCommand = new(ConvertMoney);
    }

    private void ConvertMoney()
    {
        if (Validate())
        {
            var nameOfValuteSource = SelectedMyCurrency.Content?.ToString();
            var nameOfValuteDesired = DesiredCurrency.Content?.ToString();
            Valute = nameOfValuteDesired;
            PossibleMoney = _currencyService.Convert(Convert.ToDecimal(_sourceMoney), nameOfValuteSource, nameOfValuteDesired);
        }
    }
    private bool Validate()
    {
        if (string.IsNullOrWhiteSpace(SourceMoney))
        {
            ErrorMessage = "Введите сумму для конвертации";
            return false;
        }
      
        if (!double.TryParse(SourceMoney.ToString(), out _))
        {
            ErrorMessage = "Введите корректное числовое значение";
            return false;
        }
        if (SelectedMyCurrency?.Content == null || DesiredCurrency?.Content == null)
        {
            ErrorMessage = "Выберите валюту для конвертации";
            return false;
        }
        ErrorMessage = string.Empty;
        return true;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
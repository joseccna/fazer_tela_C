using System.Globalization;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace ConversorMoedas
{
    public partial class MainPage : ContentPage
    {
        private readonly Dictionary<string, decimal> _toBRL = new()
        {
            {"BRL", 1.00m},
            {"USD", 5.60m},
            {"EUR", 6.10m}

        };

        private readonly Dictionary<string, string> _cultureByCurrency = new()
        {
            {"BRL", "pt-BR"},
            {"USD", "en-US"},
            {"EUR", "de-DE"}
        };

        public MainPage()
        {
            InitializeComponent();
            InitDefaults();
        }

        void InitDefaults()
        {
            FromPicker.SelectedIndex = IndexOf(FromPicker, "BRL");
            ToPicker.SelectedIndex = IndexOf(ToPicker, "USD");

            InfoLabel.Text = "Taxas de câmbio aproximadas apenas para fins educacionais.";
            ResultLabel.Text = string.Empty;

        }

        int IndexOf(Picker picker, string item) => picker.Items.IndexOf(item);

        void OnInverterClicked(object? sender, EventArgs e)
        {
            var formIndex = FromPicker.SelectedIndex;
            FromPicker.SelectedIndex = ToPicker.SelectedIndex;
            ToPicker.SelectedIndex = formIndex;
            
        }

        void OnPickerChanged(object? sender, EventArgs e)
        {
            ResultLabel.Text = string.Empty;
        }




        void OnAmountChanged(object? sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AcountEntry.Text))
            {
                InfoLabel.Text = "Digite um valor para converter";
            }

        }

        async void OnConverterClicked(object? sender, EventArgs e)
        {
            try
            {
                var from = GetFrom();
                var to = GetTo();

                if (string.IsNullOrWhiteSpace(AcountEntry.Text))
                {
                    await DisplayAlert("Atenção", "Informe um número valido", "OK");
                    return;
                }
                if (!decimal.TryParse(AcountEntry.Text,NumberStyles.Number, CultureInfo.CurrentCulture, out var amount) || amount < 0)
                {
                    await DisplayAlert("Atenção", "valor invalido", "OK");
                    return;
                }

                var result = Convert(from, to, amount);

                var culture = new CultureInfo(_cultureByCurrency[to]);

                var formatted = result.ToString("C", culture);

                ResultLabel.Text = $"{amount} {from} = {formatted}";

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao converter:{ex.Message}", "OK");
            }

        }

        decimal Convert(string from, string to, decimal amount)
        {
            if (from == to) return amount;
            var brl = amount * _toBRL[from];
            var result = brl / _toBRL[to];
            return decimal.Round(result, 4); 
      
        }
        string? GetFrom() => FromPicker.SelectedIndex >= 0 ? FromPicker.Items[FromPicker.SelectedIndex] : null;
        string? GetTo() => ToPicker.SelectedIndex >= 0 ? ToPicker.Items[ToPicker.SelectedIndex] : null;



    }
}

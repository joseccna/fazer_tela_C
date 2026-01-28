using Windows.Gaming.Input;

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

        private readonly Dictionary<string, string> _cultureCurrency = new()
        {
            {"BRL", "pt-BR"},
            {"USD", "en-US"},
            {"EUR", "de-DE"}
        };

        public MainPage()
        {
            InitializeComponent();
        }



    }
}

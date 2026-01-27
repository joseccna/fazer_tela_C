namespace OlaMaui
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        public void AlterarStatus(object? sender, EventArgs e)
        {
            Status.Text = "Cadastro concluido!";
        }




    }
}

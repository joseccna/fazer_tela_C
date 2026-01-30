namespace NavegacaoEntreTelas
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        async void OnEntrarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HomePage");
        }

        async void OnCadastrarClicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("Cadastro");
        }

    }
}
namespace NavegacaoEntreTelas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Cadastro), typeof(Cadastro));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegacaoEntreTelas
{
    partial class HomePage
    {
        public HomePage()
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



        async void OnsairClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }


    }
}

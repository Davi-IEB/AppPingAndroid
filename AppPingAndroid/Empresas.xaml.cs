using AppPingAndroid.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPingAndroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            lblCaminho.Text = "Caminho://ITAESBRA/";
        }
        private async void BtnDiadema_Clicked(object sender, EventArgs e)
        {
            Empresas.Empresa = "01";
            await Navigation.PushAsync(new Setor());
        }
        private async void BtnIgarassu_Clicked(object sender, EventArgs e)
        {
            Empresas.Empresa = "12";
            await Navigation.PushAsync(new Setor());
        }
        private async void BtnSair_Clicked(object sender, EventArgs e)
        {
            var resultado = await DisplayAlert("Ping", "Deseja mesmo sair?", "Sim", "Não");
            if (resultado)
            {
                System.Environment.Exit(0);
            }
        }
    }
}

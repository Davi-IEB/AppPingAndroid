using AppPingAndroid.Modelo;
using AppPingAndroid.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Centros : ContentPage
    {
        ServicoDeDados dataService;
        List<Centros> items;
        ViewCell cell;
        public Centros()
        {
            InitializeComponent();
            dataService = new ServicoDeDados();
            AtualizaDados();
        }
        private async void AtualizaDados()
        {
            items = await dataService.GetCentrosAsync();
            var queryItems = from i in items where i.Cod_empresa == Empresas.Empresa.ToString() && i.Setor == Empresas.Setor.ToString() select i;
            lvCentros.ItemsSource = queryItems;
            lblCaminho.Text = "Caminho://ITAESBRA/" + Empresas.Empresa.ToString() + "/" + Empresas.Setor.ToString();
        }
        private void BtnCapacidadeCritica_Clicked(object sender, EventArgs e)
        {

        }

        private void Linha_Tapped(object sender, EventArgs e)
        {

        }

        private void lvCentros_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
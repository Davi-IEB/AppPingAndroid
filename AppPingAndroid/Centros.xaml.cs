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
        List<Centro> items;
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
        private async void BtnCapacidadeCritica_Clicked(object sender, EventArgs e)
        {
            CentroSolicitacao.Solicitacao = "maquinas_criticas";
            await Navigation.PushAsync(new Maquinas());
        }
        private void Linha_Tapped(object sender, EventArgs e)
        {
            if (cell != null)
                cell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.FromRgb(225, 225, 225);

                cell = viewCell;
            }
        }
        private async void lvCentros_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (lvCentros.SelectedItem == null)
                return;
            if (sender is ListView list) list.BackgroundColor = Color.Transparent;
            var cent = e.Item as Centro;
            Empresas.Centro = cent.Cod_cent_trab;
            CentroSolicitacao.Solicitacao = "maquinas";
            await Navigation.PushAsync(new Maquinas());
        }
    }
}
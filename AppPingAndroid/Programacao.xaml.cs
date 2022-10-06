using AppPingAndroid.Modelo;
using AppPingAndroid.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Programacao : ContentPage
    {
        readonly ServicoDeDados DataService;
        List<Programa> programas;
        ViewCell cell;
        public Programacao()
        {
            InitializeComponent();
            DataService = new ServicoDeDados();
            AtualizaDados();
        }
        private async void AtualizaDados()
        {
            programas = await DataService.GetProgramaAsync();
            var query = from i in programas where i.Cod_empresa == Empresas.Empresa.ToString() && i.Cod_equip == Empresas.Maquina.ToString() select i;
            LvPrograma.ItemsSource = query.OrderBy(x => x.Sequencia.ToString());
            lblCaminho.Text = "Caminho://ITAESBRA/" + Empresas.Empresa.ToString() + "/" + Empresas.Setor.ToString() + "/" + Empresas.Centro.ToString() + "/" + Empresas.Maquina.ToString();
            lblMaquina.Text = Empresas.Maquina.ToString();
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

        private async void BtnDetalhe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Detalhes());
        }

        private void BtnDocumento_Clicked(object sender, EventArgs e)
        {

        }
    }
}
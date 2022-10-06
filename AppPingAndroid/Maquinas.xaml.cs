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
    public partial class Maquinas : ContentPage
    {
        ServicoDeDados dataService;
        List<Maquina> maquinas;
        ViewCell cell;
        public Maquinas()
        {
            InitializeComponent();
            dataService = new ServicoDeDados();
            AtualizaDados();

        }
        private async void AtualizaDados()
        {
            HorasDisponiveis();
            maquinas = await dataService.GetMaquinasAsync();
            foreach (var i in maquinas)
            {
                i.Horas_disponiveis = Disponibilidade.HDisponivel;
                i.Percentual = i.Horas_necessarias / Disponibilidade.HDisponivel;
                float f = (float)i.Percentual;
                if (f >= 1)
                {
                    i.StatusPercentual = "Red";
                }
                else if (f < 1 && f >= 0.9)
                {
                    i.StatusPercentual = "Yellow";
                }
                else
                {
                    i.StatusPercentual = "Black";
                }
            }
            if (CentroSolicitacao.Solicitacao.ToString() == "maquinas")
            {
                var query = from i in maquinas where i.Cod_empresa == Empresas.Empresa.ToString() && i.Cod_cent_trab == Empresas.Centro.ToString() select i;
                lvMaquinas.ItemsSource = query;
                lblCaminho.Text = "Caminho://ITAESBRA/" + Empresas.Empresa.ToString() + "/" + Empresas.Setor.ToString() + "/" + Empresas.Centro.ToString();

            }
            else if (CentroSolicitacao.Solicitacao.ToString() == "maquinas_criticas")
            {
                if (Empresas.Setor.ToString() == "ESTAMPARIA")
                {
                    var query = from i in maquinas where i.Cod_empresa == Empresas.Empresa.ToString() && i.Cod_cent_trab.Substring(0, 2).ToString() == "93" && (float)i.Percentual >= 0.9 select i;
                    lvMaquinas.ItemsSource = query;

                }
                else if (Empresas.Setor.ToString() == "SOLDA")
                {
                    var query = from i in maquinas where i.Cod_empresa == Empresas.Empresa.ToString() && i.Cod_cent_trab.Substring(0, 2).ToString() == "95" && (float)i.Percentual >= 0.9 select i;
                    lvMaquinas.ItemsSource = query;

                }
                else if (Empresas.Setor.ToString() == "USINAGEM")
                {
                    var query = from i in maquinas where i.Cod_empresa == Empresas.Empresa.ToString() && (i.Cod_cent_trab.Substring(0, 2).ToString() == "94" || i.Cod_cent_trab.Substring(0, 2).ToString() == "96") && (float)i.Percentual >= 0.9 select i;
                    lvMaquinas.ItemsSource = query;
                }
                lblCaminho.Text = "Caminho://ITAESBRA/" + Empresas.Empresa.ToString() + "/" + Empresas.Setor.ToString();
            }
        }
        private void lvMaquinas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (lvMaquinas.SelectedItem == null)
                return;
            if (sender is ListView list) list.BackgroundColor = Color.Transparent;
            var maq = e.Item as Maquina;
            Empresas.Maquina = maq.Cod_equip;
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
        private async void BtnProgramacao_Clicked(object sender, EventArgs e)
        {
            if (Empresas.Maquina == null)
                return;
            await Navigation.PushAsync(new Programacao());
        }
        private void BtnEmergencia_Clicked(object sender, EventArgs e)
        {

        }
        private void HorasDisponiveis()
        {
            DateTime DataHoraInicial;
            DateTime DataHoraFinal;
            DateTime DataHoraFinalSabado;
            TimeSpan DiferencaTempo;
            int DiaDaSemana;
            const double HorasTrabalhadasNaSemana = 15.41;
            const double HorasTrabalhadasNoSabado = 7.5;
            double SaldoDoDia = 0;
            double saldoSemanal = 0;

            DataHoraInicial = DateTime.Now;
            DataHoraFinal = new DateTime(DataHoraInicial.Year, DataHoraInicial.Month, DataHoraInicial.Day, 23, 0, 0);
            DataHoraFinalSabado = new DateTime(DataHoraInicial.Year, DataHoraInicial.Month, DataHoraInicial.Day, 13, 55, 0);
            DiaDaSemana = (int)DataHoraInicial.DayOfWeek;

            if (DiaDaSemana >= 0 && DiaDaSemana < 6)
            {
                if (DataHoraFinal >= DataHoraInicial)
                {
                    DiferencaTempo = DataHoraFinal - DataHoraInicial;
                }
                SaldoDoDia = DiferencaTempo.TotalHours;
            }
            else if (DiaDaSemana == 6)
            {
                if (DataHoraFinalSabado >= DataHoraInicial)
                {
                    DiferencaTempo = DataHoraFinalSabado - DataHoraInicial;
                }
                SaldoDoDia = DiferencaTempo.TotalHours;
            }
            if (DiaDaSemana == 0)
            {
                for (int d = 1; d <= 6; d++)
                {
                    if (d < 6)
                    {
                        saldoSemanal += HorasTrabalhadasNaSemana;
                    }
                    else if (d == 6)
                    {
                        saldoSemanal += HorasTrabalhadasNoSabado;
                    }
                }
            }
            else if (DiaDaSemana > 0)
            {
                for (int d = DiaDaSemana; d <= 6; d++)
                {
                    if (d < 6)
                    {
                        if (d == DiaDaSemana)
                        {
                            if (SaldoDoDia < 15.58)
                            {
                                saldoSemanal += SaldoDoDia;
                            }
                        }
                        else
                        {
                            saldoSemanal += HorasTrabalhadasNaSemana;
                        }
                    }
                    else if (d == 6)
                    {
                        if (d == DiaDaSemana)
                        {
                            if (SaldoDoDia < 7.50)
                            {
                                saldoSemanal += SaldoDoDia;
                            }
                        }
                        else
                        {
                            saldoSemanal += HorasTrabalhadasNoSabado;
                        }
                    }
                }
            }
            Disponibilidade.HDisponivel = Convert.ToInt32(saldoSemanal);
        }
    }
}
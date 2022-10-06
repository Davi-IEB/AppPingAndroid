using System;
using System.Collections.Generic;
using System.Text;

namespace AppPingAndroid.Modelo
{
    public class Maquina
    {
        public string Cod_empresa { get; set; }
        public string Cod_cent_trab { get; set; }
        public string Den_cent_trab { get; set; }
        public string Cod_equip { get; set; }
        public decimal Horas_necessarias { get; set; }
        public decimal Horas_disponiveis { get; set; }
        public decimal Percentual { get; set; }
        public string StatusPercentual { get; set; }
    }
    public class Disponibilidade
    {
        public static decimal HDisponivel { get; set; }
    }
    public class Programa
    {
        public string Cod_empresa { get; set; }
        public string Alerta { get; set; }
        public string Sequencia { get; set; }
        public string Num_programa { get; set; }
        public string Data_programa { get; set; }
        public string Cod_equip { get; set; }
        public string Num_ordem { get; set; }
        public string Ies_situa { get; set; }
        public string Cod_item_cliente { get; set; }
        public string Cod_item { get; set; }
        public string Operacao { get; set; }
        public string Qtd_planej { get; set; }
        public string Qtd_boas { get; set; }
        public decimal Horas_necessarias { get; set; }
        public decimal Qtd_percentual { get; set; }
        public string Obs_alerta { get; set; }
        public string Img { get; set; }
    }
}

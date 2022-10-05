using System;
using System.Collections.Generic;
using System.Text;

namespace AppPingAndroid.Modelo
{
    public class Empresas
    {
        private static string _empresa;
        public static string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        private static string _setor;
        public static string Setor
        {
            get { return _setor; }
            set { _setor = value; }
        }
        private static string _centro;
        public static string Centro
        {
            get { return _centro; }
            set { _centro = value; }
        }
        private static string _maquina;
        public static string Maquina
        {
            get { return _maquina; }
            set { _maquina = value; }
        }
    }
    public class Centros
    {
        public string Cod_empresa { get; set; }
        public string Den_reduz { get; set; }
        public string Setor { get; set; }
        public string Cod_cent_trab { get; set; }
        public string Den_cent_trab { get; set; }
    }
    public class Caminho
    {
        public string Caminho_empresa { get; set; }
    }
    public class CentroSolicitacao
    {
        private static string _centro_solicitacao;
        public static string Solicitacao
        {
            get { return _centro_solicitacao; }
            set { _centro_solicitacao = value; }
        }
    }
}

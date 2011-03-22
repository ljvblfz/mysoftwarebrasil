using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCadDesktopData.Data.Model.Relatorio
{
    public class AlteracaoCadastral
    {
        public AlteracaoCadastral()
        {

        }

        public AlteracaoCadastral(string codigoDistrito, string setor, string codigoRota, string matricula, string numeroPontoServico, string informacao, string valorAntigo, string valorNovo)
        {
            CodigoRota = codigoRota;
            CodigoDistrito = codigoDistrito;
            Setor = setor;
            Matricula = matricula;
            NumeroPontoServico = numeroPontoServico;
            Informacao = informacao;
            ValorAntigo = valorAntigo;
            ValorNovo = valorNovo;
        }

        public AlteracaoCadastral(string informacao, string valorAntigo, string valorNovo)
        {
            CodigoRota = "";
            CodigoDistrito = "";
            Setor = "";
            Matricula = "";
            NumeroPontoServico = "";
            Informacao = informacao;
            ValorAntigo = valorAntigo;
            ValorNovo = valorNovo;
        }

        public string CodigoRota { get; set; }

        public string CodigoDistrito { get; set; }

        public string Setor { get; set; }

        public string Matricula { get; set; }

        public string NumeroPontoServico { get; set; }

        public string Informacao { get; set; }

        public string ValorAntigo { get; set; }

        public string ValorNovo { get; set; }
    }
}

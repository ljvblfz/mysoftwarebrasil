using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelpDesktop;

namespace SPCadDesktopData.Data.Model.Relatorio
{
    public class Irregularidade
    {
        public string irregularidade { get; set; }

        public DateTime dataInicial { get; set; }

        public DateTime dataFinal { get; set; }

        public int distrito { get; set; }

        public int setor { get; set; }

        public int rota { get; set; }

        public int situacao { get; set; }
    }
}

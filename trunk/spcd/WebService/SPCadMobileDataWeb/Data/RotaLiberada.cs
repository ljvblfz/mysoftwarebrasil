using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPCadMobileDataWeb.Data
{
    public class RotaLiberada
    {
        public int distrito { get; set; }
        public int setor { get; set; }
        public int rota { get; set; }
        public int qtd { get; set; }

        public RotaLiberada()
        {
        }

        public RotaLiberada(int distrito, int setor, int rota, int qtd)
        {
            this.distrito = distrito;
            this.setor = setor;
            this.rota = rota;
            this.qtd = qtd;
        }       
    }
}

using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Encontro
    {


        public Encontro()
        {
        }

        public Encontro(int Encontroid, Endereco Enderecoid, string Encontrotitulo,string  Encontrodescricao, int Encontroquantpessoa, DateTime Encontrodata, double Encontrovalor)
        {
            this.Encontroid = Encontroid;
            this.Enderecoid = Enderecoid;
            this.Encontrotitulo = Encontrotitulo;
            this.Encontrodescricao = Encontrodescricao;
            this.Encontroquantpessoa = Encontroquantpessoa;
            this.Encontrodata = Encontrodata;
            this.Encontrovalor = Encontrovalor;
        }

        public virtual int Encontroid { get; set; }
        public virtual Endereco Enderecoid { get; set; }
        public virtual string Encontrotitulo { get; set; }
        public virtual string Encontrodescricao { get; set; }
        public virtual int Encontroquantpessoa { get; set; }
        public virtual DateTime Encontrodata { get; set; }
        public virtual double Encontrovalor { get; set; }
        public virtual IList<Encontromembro> EncontromembroList { get; set; }
        public virtual IList<Encontromembro> MembroidList { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Perfil
    {


        public Perfil()
        {
        }

        public Perfil(int Perfilid, int Perfilaltura, int Perfilpeso, string Perfilfumante, string Perfilbebe,string  Pessoainteresseconhecer,string  Pessoafantasiassexuai,string  Pessoaoutrosinteresse)
        {
            this.Perfilid = Perfilid;
            this.Perfilaltura = Perfilaltura;
            this.Perfilpeso = Perfilpeso;
            this.Perfilfumante = Perfilfumante;
            this.Perfilbebe = Perfilbebe;
            this.Pessoainteresseconhecer = Pessoainteresseconhecer;
            this.Pessoafantasiassexuai = Pessoafantasiassexuai;
            this.Pessoaoutrosinteresse = Pessoaoutrosinteresse;
        }

        public virtual int Perfilid { get; set; }
        public virtual int Perfilaltura { get; set; }
        public virtual int Perfilpeso { get; set; }
        public virtual string Perfilfumante { get; set; }
        public virtual string Perfilbebe { get; set; }
        public virtual string Pessoainteresseconhecer { get; set; }
        public virtual string Pessoafantasiassexuai { get; set; }
        public virtual string Pessoaoutrosinteresse { get; set; }
        public virtual IList<Pessoa> PessoaList { get; set; }
        public virtual IList<Pessoa> SexoidList { get; set; }

    }
}

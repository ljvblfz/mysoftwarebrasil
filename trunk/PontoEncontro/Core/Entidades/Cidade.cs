using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Cidade
    {


        public Cidade()
        {
        }

        public Cidade(int Cidadeid, string Cidadename, Estado Estadoid)
        {
            this.Cidadeid = Cidadeid;
            this.Cidadename = Cidadename;
            this.Estadoid = Estadoid;
        }

        public virtual int Cidadeid { get; set; }
        public virtual string Cidadename { get; set; }
        public virtual Estado Estadoid { get; set; }
        public virtual IList<Endereco> EnderecoList { get; set; }
        public virtual IList<Endereco> CidadeidList { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Estado
    {


        public Estado()
        {
        }

        public Estado(int Estadoid, string Estadoname, string Estadosigla, Pai Paisid)
        {
            this.Estadoid = Estadoid;
            this.Estadoname = Estadoname;
            this.Estadosigla = Estadosigla;
            this.Paisid = Paisid;
        }

        public virtual int Estadoid { get; set; }
        public virtual string Estadoname { get; set; }
        public virtual string Estadosigla { get; set; }
        public virtual Pai Paisid { get; set; }
        public virtual IList<Cidade> CidadeList { get; set; }
        public virtual IList<Cidade> EstadoidList { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Comunidade
    {


        public Comunidade()
        {
        }

        public Comunidade(int Comunidadeid, string Comunidadename, DateTime Comunidadedatacreate,string  Comunidadedescricao)
        {
            this.Comunidadeid = Comunidadeid;
            this.Comunidadename = Comunidadename;
            this.Comunidadedatacreate = Comunidadedatacreate;
            this.Comunidadedescricao = Comunidadedescricao;
        }

        public virtual int Comunidadeid { get; set; }
        public virtual string Comunidadename { get; set; }
        public virtual DateTime Comunidadedatacreate { get; set; }
        public virtual string Comunidadedescricao { get; set; }
        public virtual IList<Comunidademembro> ComunidademembroList { get; set; }
        public virtual IList<Comunidademembro> ComunidadeidList { get; set; }

    }
}

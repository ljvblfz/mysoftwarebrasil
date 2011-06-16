using System;
using System.Collections.Generic;

namespace Core
{
    [Serializable]
    public class Amigo
    {


        public Amigo()
        {
        }

        public Amigo(int Amigoid)
        {
            this.Amigoid = Amigoid;
        }

        public virtual int Amigoid { get; set; }
        public virtual IList<Membroamigo> MembroamigoList { get; set; }
        public virtual IList<Membroamigo> MembroidList { get; set; }

    }
}
